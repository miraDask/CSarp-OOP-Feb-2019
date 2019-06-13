namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Models.Heroes.HeroContracts;
    using MuOnline.Utilities;

    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroType, string username)
        {
            heroType = heroType.ToLower();
            username = username.ToLower();

            var classType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == heroType);

            Validator.ObjecIsNotNullValidation(classType);

            var heroInstance =(IHero)Activator
                .CreateInstance(classType, username);

            return heroInstance;
        }
    }
}
