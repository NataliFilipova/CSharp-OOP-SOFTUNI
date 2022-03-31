using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    internal class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racer = new List<IRacer>();
        public RacerRepository()
        {
            this.racer = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models { get => this.racer; }

        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }
            else
            {
                this.racer.Add(racer);
            }
        }

        public IRacer FindBy(string property)
        {
            return this.racer.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer racer)
        {
            return this.racer.Remove(racer);    
        }
    }
}
