namespace P05_GreedyTimes
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] safeContent = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag(capacity);

            for (int i = 0; i < safeContent.Length; i += 2)
            {
                string nameOfItem = safeContent[i];
                long amount = long.Parse(safeContent[i + 1]);

                string typeOfItem = GetType(nameOfItem);

                bool skipTheItem = bag.ItemMustBeSkipped(amount, typeOfItem);

                if (skipTheItem == true)
                {
                    continue;
                }

                bag.AddItem(typeOfItem, amount, nameOfItem);

            }

            Console.WriteLine(bag);
        }

        private static string GetType(string nameOfItem)
        {
            var typeOfItem = string.Empty;

            if (nameOfItem.Length == 3)
            {
                typeOfItem = "Cash";
            }
            else if (nameOfItem.ToLower().EndsWith("gem"))
            {
                typeOfItem = "Gem";
            }
            else if (nameOfItem.ToLower() == "gold")
            {
                typeOfItem = "Gold";
            }

            return typeOfItem;
        }
    }
}