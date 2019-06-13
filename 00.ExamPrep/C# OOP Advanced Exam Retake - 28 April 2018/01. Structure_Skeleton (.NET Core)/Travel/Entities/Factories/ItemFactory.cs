namespace Travel.Entities.Factories
{
	using Contracts;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            //switch (type)
            //{
            //	case "CellPhone":
            //		return new CellPhone();
            //	case "Colombian":
            //		return new Colombian();
            //	case "Jewelery":
            //		return new Jewelery();
            //	case "Laptop":
            //		return new Laptop();
            //	case "toothbrush":
            //		return new Toothbrush();
            //	case "TravelKit":
            //		return new TravelKit();
            //	default:
            //		return new Soap();
            //}

            var itemType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            return (IItem)Activator.CreateInstance(itemType);

		}
	}
}
