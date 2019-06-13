using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public IDrink CreateDrink(string drinkType ,string name, int servingSize, string brand)
        {
        //    var type = Assembly
        //        .GetCallingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(x => x.Name == drinkType);

        //    return (IDrink)Activator
        //            .CreateInstance(type,
        //            new object[] { name, servingSize, brand});

            return (IDrink)Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == drinkType)
                .GetConstructors()
                .First()
                .Invoke(new object[] { name, servingSize, brand });
        }
    }
}
