namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        public RandomList()
        {
            this.RandomGenerator = new Random();
        }

        public Random RandomGenerator { get; set; }

        public string RandomString()
        {
            int index = this.RandomGenerator.Next(0, this.Count);
            string randomText = this[index];
            this.RemoveAt(index);

            return randomText;
        }
    }
}
