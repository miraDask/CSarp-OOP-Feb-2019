namespace MuOnline.Core.Commands
{
    using Core.Commands.Contracts;
    using Models.Heroes.HeroContracts;
    using Models.Items.Contracts;
    using Utilities;
    using Repositories.Contracts;

    public class AddItemToHeroCommand : ICommand
    {
        private const string SuccessfullOperation = "Successfully added {0} to {1}!";
        private IRepository<IHero> heroRepository;
        private IRepository<IItem> itemRepository;

        public AddItemToHeroCommand(IRepository<IHero> heroRepository, IRepository<IItem> itemRepository)
        {
            this.heroRepository = heroRepository;
            this.itemRepository = itemRepository;
        }

        public string Execute(string[] inputArgs)
        {
            Validator.InputLengthValidate(inputArgs);

            var heroUserName = inputArgs[0];
            var itemType = inputArgs[1];

            var hero = heroRepository.Get(heroUserName);
            var item = itemRepository.Get(itemType);

            hero.Inventory.AddItem(item);

            return string.Format(SuccessfullOperation, itemType, heroUserName);
        }
    }
}
