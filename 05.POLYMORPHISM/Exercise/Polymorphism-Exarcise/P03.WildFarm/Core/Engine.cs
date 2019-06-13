namespace P03.WildFarm.Core
{
    using Factories;
    using Models.Animals;
    using Models.Food;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        public static List<Animal> animals = new List<Animal>();
        public static Animal currentAnimal;

        public void Run()
        {
            int inputCount = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (inputCount % 2 == 0)
                {
                    currentAnimal = AnimalFactory.CreateAnimal(input);
                    Console.WriteLine(currentAnimal.ProduceSound());
                    animals.Add(currentAnimal);
                }
                else
                {
                    Food food = FoodFactory.CreateFood(input);

                    try
                    {
                        currentAnimal.Eat(food);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                inputCount++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
