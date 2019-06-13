namespace P07.InfernoInfinity.Models
{
    using P07.InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string typeOfWeapon,string name, string rarityType)
        {
            var rarity = Enum.Parse<Rarity>(rarityType);

            var classType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeOfWeapon);

            var instance = Activator.CreateInstance(classType, new object[] {name,rarity});
            return (IWeapon)instance;
        }
    }
}