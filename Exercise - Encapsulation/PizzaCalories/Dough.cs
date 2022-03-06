using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> FlourType = new Dictionary<string, double>()
        {
            { "white" ,1.5 },
            { "wholegrain" , 1.0 }
        };
        private Dictionary<string, double> BakingTechnique = new Dictionary<string, double>()
        {
            {"crispy" , 0.9 },
            {"chewy" , 1.1 },
            {"homemade" , 1.0 }
        };
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flour, string baking, double weight)
        {
            Flour = flour;
            Baking = baking;
            Weight = weight;
        }

        public string Flour
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!FlourType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string Baking
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!BakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public double Calories => 2 * this.weight * FlourType[Flour.ToLower()] * BakingTechnique[Baking.ToLower()];
    }
}