namespace MuOnline.Models.Inventories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Items.Contracts;
    using Utilities;

    public class Inventory : IInventory
    {
        private readonly List<IItem> items;

        public Inventory()
        {
            this.items = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Items  => items.AsReadOnly(); 

        public void AddItem(IItem item)
        {
            Validator.ObjecIsNotNullValidation(item);
            this.items.Add(item);
        }

        public bool RemoveItem(IItem item)
        {
            var targetItem = this.items.FirstOrDefault(x => x.GetType().Name == item.GetType().Name);

            Validator.ObjecIsNotNullValidation(targetItem);

            return this.items.Remove(targetItem);
        }

        public IItem GetItem(string item)
        {
            var targetItem = this.items.FirstOrDefault(x => x.GetType().Name == item);

            Validator.ObjecIsNotNullValidation(targetItem);

            return targetItem;
        }
    }
}
