using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            ICar myCar = null;
            if (type == "SuperCar")
            {
                myCar = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                myCar = new TunedCar(make, model, VIN, horsePower);
            }
            cars.Add(myCar);
            string result = string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            return result;
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar myCar = cars.FindBy(carVIN);
            if (myCar == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            IRacer myRacer = null;
            if (type == "ProfessionalRacer")
            {
                myRacer = new ProfessionalRacer(username, myCar);
            }
            else if (type == "StreetRacer")
            {
                myRacer = new StreetRacer(username, myCar);
            }
            racers.Add(myRacer);
            string result = string.Format(OutputMessages.SuccessfullyAddedRacer, username);
            return result;
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            string result = map.StartRace(racerOne, racerTwo);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
