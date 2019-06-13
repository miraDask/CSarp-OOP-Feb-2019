namespace P05_GreedyTimes
{
    public class Item
    {
        public Item(string type)
        {
            this.Name = type;
        }

        public string Name { get; private set; }

        public long Amount { get; set; }
    }
}
