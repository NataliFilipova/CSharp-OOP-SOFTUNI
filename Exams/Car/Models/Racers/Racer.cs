using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    internal abstract class Racer : IRacer
    {
        private string username;

        private string racingBehavior;

        private int drivingExperience;

        private ICar car;
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get
            {
                return this.racingBehavior;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }
                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get
            {
                return this.drivingExperience;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get
            {
                return this.car;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.car.FuelAvailable - this.car.FuelConsumptionPerRace >= 0)
            {
                return true;
            }
            return false;
        }

        public virtual void Race()
        {
            this.car.Drive();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Username}");
            sb.AppendLine($"--Driving behavior: {RacingBehavior}");
            sb.AppendLine($"--Driving experience: {DrivingExperience}");
            sb.AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");
            return sb.ToString().TrimEnd();
        }
    }
}
