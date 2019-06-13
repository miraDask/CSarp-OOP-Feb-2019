using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMaster.Models.Factories
{
    public class ProductFactory
    {
        public Product GetProduct(string productType, double price)
        {

            var type = Assembly
                        .GetCallingAssembly()
                        .GetTypes()
                        .FirstOrDefault(x => x.Name == productType);

            return (Product)Activator
                    .CreateInstance(type,
                    new object[] { price });
        }
    }
}
