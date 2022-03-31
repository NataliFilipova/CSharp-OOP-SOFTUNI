using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    internal abstract class Car : ICar
    {
        private string make;

        private string model;

        private string vin;

        private int horsePower;

        private double fuelAvailable;

        private double fuelConsumptionPerRace;
        public Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public string Make
        {
            get
            {
                return make;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                make = value;
            }
        }


        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                this.model = value;
            }
        }

        public string VIN
        {
            get
            {
                return this.vin;
            }
            set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                this.vin = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get
            {
                return fuelAvailable;
            }
            set
            {
                if (value < 0)
                {
                    fuelAvailable = 0;
                }
                else
                {
                    fuelAvailable = value;
                }
            }
        }

        public double FuelConsumptionPerRace
        {
            get
            {
                return fuelConsumptionPerRace;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            fuelAvailable -= fuelConsumptionPerRace;
        }
    }
}
