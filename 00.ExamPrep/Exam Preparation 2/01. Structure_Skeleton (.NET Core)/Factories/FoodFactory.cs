using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public IFood CreateFood(string foodtype, string name, decimal price)
        {
            //var type = Assembly
            //    .GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == foodtype);

            //return (IFood)Activator
            //        .CreateInstance(type,
            //        new object[] {name, price});

            return (IFood)Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == foodtype)
                .GetConstructors()
                .First()
                .Invoke(new object[] { name, price});
        }
    }
}
