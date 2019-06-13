namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        private string name;
        private decimal money;
        private List<string> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.bagOfProducts = new List<string>();
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public bool AddProduct(Product product)
        {
            if (this.Money < product.Cost )
            {
                return false;
            }

            this.bagOfProducts.Add(product.Name);
            this.Money -= product.Cost;
            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{this.Name} - ");

            if (this.bagOfProducts.Count == 0)
            {
                result.Append("Nothing bought");
            }
            else
            {
                result.Append(string.Join(", ", this.bagOfProducts));
            }
            return result.ToString();
        }
    }
}
