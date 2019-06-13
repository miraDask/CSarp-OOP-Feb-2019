namespace p07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Person : IBuyer
    {
        private string name;
        private string age;
        private HashSet<string> names = new HashSet<string>();

        
        public Person(string name, string age)
        {
            this.Name = name;
            this.age = age;
            this.Food = 0;
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                bool nameIsAvaliable = this.AddName(value);

                if (nameIsAvaliable == false)
                {
                    throw new ArgumentException("This name is not avaliable");
                }

                this.name = value;
            }
        }

        public int Food { get; protected set; }

        public abstract void BuyFood();
        
        private bool AddName(string name)
        {
            if (!this.names.Contains(name))
            {
                this.names.Add(name);
                return true;
            }

            return false;
        }
    }
}
