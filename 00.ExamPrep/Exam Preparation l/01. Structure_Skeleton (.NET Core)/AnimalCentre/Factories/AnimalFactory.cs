using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animalType = Assembly
                 .GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == type);

            return (IAnimal)Activator
                    .CreateInstance(animalType,
                    new object[] { name, energy, happiness, procedureTime});
        }
    }
}
