namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var assembly = typeof(AppEntryPoint).Assembly;
            var currentUnitType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == unitType);

            return (IUnit)Activator.CreateInstance(currentUnitType);
        }
    }
}
