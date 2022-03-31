using Easter.Core.Contracts;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunny = new BunnyRepository();
        private EggRepository egg = new EggRepository();
        private IWorkshop workshop = new Workshop();
        private int countOfColouredEggs = 0;
        public string AddBunny(string bunnyType, string bunnyName)
        {
           IBunny bun;
           if(bunnyType == "HappyBunny")
            {
                bun = new HappyBunny(bunnyName);
            }
           else if(bunnyType == "SleepyBunny")
            {
                bun = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunny.Add(bun);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunnys = bunny.FindByName(bunnyName);
            if(bunnys == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            bunnys.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);

        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg eggs = new Egg(eggName, energyRequired);
            egg.Add(eggs);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {

            var readyBunnies = bunny.Models.Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            IEgg eggs = egg.FindByName(eggName);

            if (!readyBunnies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            foreach(var buns in readyBunnies)
            {
                workshop.Color(eggs, buns);
                if(buns.Energy == 0)
                {
                    bunny.Remove(buns);
                }
            }
            string result = "";
            if (eggs.IsDone())
            {
                result = string.Format(OutputMessages.EggIsDone, eggName);
                countOfColouredEggs++;
            }
            else
            {
                result = string.Format(OutputMessages.EggIsNotDone, eggName);
            }
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{countOfColouredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach(var bun in bunny.Models)
            {
                sb.AppendLine($"Name: {bun.Name}");
                sb.AppendLine($"Energy: {bun.Energy}");
                var countNotCompletedDyes = bun.Dyes.Where(x => !x.IsFinished()).ToList().Count();
                
                sb.AppendLine($"Dyes: {countNotCompletedDyes} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
