using System;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine().Split(' ');
                string[] dought = Console.ReadLine().Split(' ');
                Dough dough = new Dough(dought[1], dought[2], double.Parse(dought[3]));
                Pizza pizza = new Pizza(pizzaName[1], dough);
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] toping = command.Split(' ');
                    Topping topping = new Topping(toping[1], double.Parse(toping[2]));
                    pizza.AddTopping(topping);
                    command = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}