namespace PizzaCalories
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var pizzaName = Console.ReadLine().Split();
                var name = pizzaName[1];
                

                var doughData = Console.ReadLine().Split();
                var flourType = doughData[1];
                var bakingType = doughData[2];
                var weight = double.Parse(doughData[3]);
                var dough = new Dough(flourType, bakingType, weight);
                var pizza = new Pizza(name,dough);

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var toppingData = input.Split();
                    var type = toppingData[1];
                    var toppingWeight = double.Parse(toppingData[2]);
                    var topping = new Topping(type, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
