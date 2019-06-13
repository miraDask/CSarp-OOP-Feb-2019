namespace MuOnline.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Items.Contracts;
    using Utilities;

    public class ItemRepository : IRepository<IItem>
    {
        private readonly List<IItem> itemRepository;

        public ItemRepository()
        {
            this.itemRepository = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Repository
            => this.itemRepository.AsReadOnly();

        public void Add(IItem item)
        {
            Validator.ObjecIsNotNullValidation(item);
            this.itemRepository.Add(item);
        }

        public bool Remove(IItem item)
        {
            Validator.ObjecIsNotNullValidation(item);

            return this.itemRepository.Remove(item);
        }

        public IItem Get(string item)
        {
            item = item.ToLower();

            var targetItem = this.itemRepository.FirstOrDefault(x => x.GetType().Name.ToLower() == item);

            Validator.ObjecIsNotNullValidation(targetItem);

            return targetItem;
        }
    }
}
