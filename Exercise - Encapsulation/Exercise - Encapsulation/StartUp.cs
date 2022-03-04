using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] peopleInfo = Console.ReadLine().Split(new char[] { ';', '='}, StringSplitOptions.RemoveEmptyEntries) ;
            string[] productInfo = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInfo.Length; i += 2) 
            {
                string name = peopleInfo[i];
                decimal money = decimal.Parse(peopleInfo[i + 1]);
                Person currentPerson = null;
                try
                {
                    currentPerson = new Person(name, money);
                    people[name] = currentPerson;
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            for (int i = 0; i < productInfo.Length; i += 2)
            {
                string name = productInfo[i];
                decimal cost = decimal.Parse(productInfo[i + 1]);
               
                Product currentProduct = null;
                try
                {
                   currentProduct = new Product(name, cost);
                    products[name] = currentProduct;
                }
                 catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }

            }
            string input = Console.ReadLine();

            while(input != "END")
            {
                string[] splitted = input.Split(" ");
                string name = splitted[0];
                string product = splitted[1];

                if(people[name].Money < products[product].Cost)
                {
                    Console.WriteLine($"{name} can't afford {product}");
                }
                else
                {
                    people[name].Money -= products[product].Cost;
                    people[name].Products.Add(product);
                    Console.WriteLine($"{name} bought {product}");
                }

                input = Console.ReadLine();
            }

            foreach(var person in people)
            {
                Console.Write($"{person.Key} - ");
                if(person.Value.Products.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", person.Value.Products));
                }
            }
        }
    }
}
