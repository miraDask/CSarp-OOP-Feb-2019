namespace p06.Animals.Core
{
    using p06.Animals.Animals;
    using p06.Animals.Factiries;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();
            AnimalFactory animalFactory = new AnimalFactory();

            while (true)
            {
                string firstLine = Console.ReadLine();

                if (firstLine == "Beast!")
                {
                    break;
                }

                string typeOfAnimal = firstLine;

                string[] animalData = Console.ReadLine().Split();

                string name = animalData[0];
                string age = animalData[1];
                string gender = string.Empty;

                if (animalData.Length > 2)
                {
                    gender = animalData[2];
                }

                try
                {
                    var animal = animalFactory.CreateAnimal(typeOfAnimal, name, age, gender);

                    animals.Add(animal);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
