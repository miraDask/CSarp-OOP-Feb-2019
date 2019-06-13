namespace ArrayDatabase
{
    using System;
    using System.Collections.Generic;

    public class Database
    {
        private const int Capacity = 16;
        private List<int> numbers;

        public Database(params int[] numbers)
        {
            this.Numbers = new List<int>(numbers);
        }

        private List<int> Numbers
        {
            get => this.numbers;
            set
            {
                if (value.Count > Capacity || value.Count == 0)
                {
                    throw new InvalidOperationException("Invalid count of elements!");
                }

                this.numbers = value;
            }
        }

        public void Add(int element)
        {
            int newLength = this.numbers.Count + 1;

            if (newLength > 16)
            {
                throw new InvalidOperationException();
            }

            this.numbers.Add(element);
        }

        public void Remove()
        {
            if (this.numbers.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            int lastIndex = this.numbers.Count - 1;
            this.numbers.RemoveAt(lastIndex);
        }

        public int[] FetchAllStoredData()
        {
            var data = new int[Capacity];

            for (int i = 0; i < this.numbers.Count; i++)
            {
                data[i] = this.numbers[i];
            }

            return data;
        }
    }
}
