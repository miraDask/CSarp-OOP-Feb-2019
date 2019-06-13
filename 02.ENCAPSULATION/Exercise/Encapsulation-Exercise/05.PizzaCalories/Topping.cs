namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private const int baseCalories = 2;
        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (value.ToLower() != "meat"
                    && value.ToLower() != "veggies"
                     && value.ToLower() != "cheese"
                     && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {

                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories => GetCalories();

        private double GetCalories()
        {
            var modifier = 0.0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }

            var calories = baseCalories * this.Weight * modifier;
            return calories;
        }
    }
}
