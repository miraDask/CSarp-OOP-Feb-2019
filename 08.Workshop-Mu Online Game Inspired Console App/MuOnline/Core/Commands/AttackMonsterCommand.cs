namespace MuOnline.Core.Commands
{
    using Core.Commands.Contracts;
    using Models.Heroes.HeroContracts;
    using Models.Monsters.Contracts;
    using Repositories.Contracts;
    using Utilities;

    class AttackMonsterCommand : ICommand
    {
        private const string CommandMessage = "{0} is dead";
        private IRepository<IHero> heroRepository;
        private IRepository<IMonster> monsterRepository;

        public AttackMonsterCommand(IRepository<IHero> heroRepository, IRepository<IMonster> monsterRepository)
        {
            this.heroRepository = heroRepository;
            this.monsterRepository = monsterRepository;
        }

        public string Execute(string[] inputArgs)
        {

            Validator.InputLengthValidate(inputArgs);

            var heroUserName = inputArgs[0];
            var monsterType = inputArgs[1];

            var hero = heroRepository.Get(heroUserName);
            var monster = monsterRepository.Get(monsterType);

            var heroAttackPoints = hero.TotalAttackPoints;
            var monsterAttackPoints = monster.AttackPoints;

            while (hero.IsAlive && monster.IsAlive)
            {
                hero.TakeDamage(monsterAttackPoints);

                if (hero.IsAlive)
                {
                    var heroExperience = monster.TakeDamage(heroAttackPoints);
                    ((IProgress)hero).AddExperience(heroExperience);
                }
            }

            return string.Format(CommandMessage, hero.IsAlive ? monster.GetType().Name : heroUserName);
        }
    }
}
