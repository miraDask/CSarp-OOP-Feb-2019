namespace MuOnline.Core.Commands
{
    using Contracts;
    using Factories.Contracts;
    using Models.Items.Contracts;
    using MuOnline.Utilities;
    using Repositories.Contracts;
    using System;

    public class AddItemCommand : ICommand
    {
        private const string SuccessfullOperation = "Successfully created new {0}!";
        private readonly IRepository<IItem> itemRepository;
        private readonly IItemFactory itemFactory;

        public AddItemCommand(IRepository<IItem> itemRepository, IItemFactory itemFactory)
        {
            this.itemRepository = itemRepository;
            this.itemFactory = itemFactory;
        }

        public string Execute(string[] inputArgs)
        {
            var itemType = inputArgs[0];

            var item = this.itemFactory.Create(itemType);

            this.itemRepository.Add(item);

            return string.Format(SuccessfullOperation, itemType);
        }
    }
}
