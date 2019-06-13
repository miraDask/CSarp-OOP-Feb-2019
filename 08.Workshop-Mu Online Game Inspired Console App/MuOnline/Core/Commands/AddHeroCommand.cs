namespace MuOnline.Core.Commands
{
    using Core.Commands.Contracts;
    using Core.Factories.Contracts;
    using Models.Heroes.HeroContracts;
    using Repositories.Contracts;
    using Utilities;

    public class AddHeroCommand : ICommand
    {
        private const string SuccessfullOperation = "Successfully created new {0}!";
        private readonly IRepository<IHero> heroRepository;
        private readonly IHeroFactory heroFactory;

        public AddHeroCommand(IRepository<IHero> itemRepository, IHeroFactory heroFactory)
        {
            this.heroRepository = itemRepository;
            this.heroFactory = heroFactory;
        }

        public string Execute(string[] inputArgs)
        {
            Validator.InputLengthValidate(inputArgs);

            var heroType = inputArgs[0];
            var username = inputArgs[1];

            var hero = this.heroFactory.Create(heroType ,username);

            this.heroRepository.Add(hero);

            return string.Format(SuccessfullOperation, hero.GetType().Name);
        }
    }
}
