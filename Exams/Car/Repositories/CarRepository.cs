using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    internal class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars = new List<ICar>();
        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models { get => this.cars;}

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            else
            {
                this.cars.Add(model);
            }
        }

        public ICar FindBy(string property)
        {
            return this.cars.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }
    }
}
