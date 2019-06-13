namespace P05_GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private long capacity;
        private Dictionary<string, List<Item>> bag;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.bag = new Dictionary<string, List<Item>>();
        }

        public long TotalAmount => this.bag.Values.Select(x => x.Select(y => y.Amount).Sum()).Sum();

        public void AddItem(string typeOfItem, long amount, string nameOfItem)
        {
           // bool bagHasMoreFreeSpace = 

            if (!bag.ContainsKey(typeOfItem))
            {
                bag[typeOfItem] = new List<Item>();
            }

            if (!bag[typeOfItem].Any(x => x.Name == nameOfItem))
            {
                bag[typeOfItem].Add(new Item(nameOfItem));
            }

            var currentItem = bag[typeOfItem].Find(x => x.Name == nameOfItem);

            currentItem.Amount += amount;

        }

        public bool ItemMustBeSkipped(long amount, string typeOfItem)
        {

            if (typeOfItem == "")
            {
                return true;
            }
            else if (this.capacity < this.TotalAmount + amount)
            {
                return true;
            }

           
            

            switch (typeOfItem)
            {
                case "Gem":
                    if (!this.bag.ContainsKey(typeOfItem))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                           var currentGoldAmount = bag["Gold"].Select(x => x.Amount).Sum();

                            if (amount > currentGoldAmount)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag["Gem"].Select(x => x.Amount).Sum() + amount > bag["Gold"].Select(x => x.Amount).Sum())
                    {
                        return true;
                    }
                    break;

                case "Cash":
                    if (!bag.ContainsKey(typeOfItem))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                           var currentGemAmount = bag["Gem"].Select(x => x.Amount).Sum();

                            if (amount > currentGemAmount)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag["Cash"].Select(x => x.Amount).Sum() + amount > bag["Gem"].Select(x => x.Amount).Sum())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var pair in this.bag.OrderByDescending(x => x.Value.Select(y => y.Amount).Sum()))
            {
                var typeOfItem = pair.Key;
                var collectionOfSameTypeItems = pair.Value;
                var collectionTotalAmount = collectionOfSameTypeItems.Select(y => y.Amount).Sum();

                result.AppendLine($"<{typeOfItem}> ${collectionTotalAmount}");

                foreach (Item item in collectionOfSameTypeItems.OrderByDescending(y => y.Name).ThenBy(y => y.Amount))
                {
                    result.AppendLine($"##{item.Name} - {item.Amount}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
