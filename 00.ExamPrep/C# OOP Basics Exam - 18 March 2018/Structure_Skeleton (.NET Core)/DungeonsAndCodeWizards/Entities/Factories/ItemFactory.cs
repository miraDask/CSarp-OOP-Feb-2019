using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Factories
{
    public class ItemFactory
    {
        public Item GetItem(string itemType)
        {
            var type = Assembly
               .GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name == itemType);

            try
            {
                return (Item)Activator
                   .CreateInstance(type);
            }
            catch (Exception)
            {
                return null;
            }
           
        }
    }
}
