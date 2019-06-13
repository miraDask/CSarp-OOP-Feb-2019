namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Items.Contracts;
    using Utilities;

    public class ItemFactory : IItemFactory
    {
        public IItem Create(string itemType)
        {
            itemType = itemType.ToLower();

            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == itemType);

             Validator.ObjecIsNotNullValidation(type);

            var item = (IItem)Activator.CreateInstance(type);

            return item;
        }
    }
}
