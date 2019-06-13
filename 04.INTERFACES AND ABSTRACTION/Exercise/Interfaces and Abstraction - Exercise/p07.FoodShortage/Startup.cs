namespace p07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Person> buyers = new List<Person>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                string age = input[1];

                try
                {
                    if (input.Length > 3)
                    {
                        string id = input[2];
                        string birthdate = input[3];

                        Citizen citizen = new Citizen(name, age , id, birthdate);
                        buyers.Add(citizen);
                    }
                    else
                    {
                        string rebelGroup = input[2];

                        Rebel rebel = new Rebel(name, age, rebelGroup);
                        buyers.Add(rebel);
                    }
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (buyers.Any(x => x.Name == name))
                {
                    Person person = buyers.Find(x => x.Name == name);

                    person.BuyFood();
                }
            }

            int totoalFood = buyers.Select(x => x.Food).Sum();

            Console.WriteLine(totoalFood);
        }
    }
}
