namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Core.Factories.Contracts;
    using Models.Monsters.Contracts;
    using Utilities;

    public class MonsterFactory : IMonsterFactory
    {
        public IMonster Create(string monsterType)
        {
            monsterType = monsterType.ToLower();

            var classType = Assembly
               .GetExecutingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name.ToLower() == monsterType);

            Validator.ObjecIsNotNullValidation(classType);

            var monsterInstance = (IMonster)Activator
                .CreateInstance(classType);

            return monsterInstance;
        }
    }
}
