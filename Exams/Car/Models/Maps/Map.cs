using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    internal class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();
                double racerOneChanses = 0;
                double racerTwoChanses = 0;
                if (racerOne.RacingBehavior == "strict")
                {
                    racerOneChanses += racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
                }
                else
                {
                    racerOneChanses += racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
                }
                if (racerTwo.RacingBehavior == "strict")
                {
                    racerTwoChanses += racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
                }
                else
                {
                    racerTwoChanses += racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
                }
                string winner = "";
                if (racerOneChanses > racerTwoChanses)
                {
                    winner = racerOne.Username;
                }
                else
                {
                    winner = racerTwo.Username;
                }
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner} is the winner!";
            }
        }
    }
}
