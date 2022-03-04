using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<string> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
               
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
               
                    if (value < 0)
                    {
                        throw new ArgumentException("Money cannot be negative.");
                    }

                    this.money = value;

            }
        }

        public List<string> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }
    }
}
