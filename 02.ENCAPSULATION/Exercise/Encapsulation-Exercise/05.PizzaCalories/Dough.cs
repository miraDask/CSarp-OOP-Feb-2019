namespace PizzaCalories
{
    using System;

    public class Dough
    {
        private const int baseCalories = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white"
                && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy"
                    && value.ToLower() != "chewy"
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double Calories => this.GetCalories();

        private double GetCalories()
        {
            var flourModifier = this.FlourType.ToLower() == "white"? 1.5 : 1.0;

            var bakingdModifier = 0.0;

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingdModifier = 0.9;
                    break;
                case "chewy":
                    bakingdModifier = 1.1;
                    break;
                case "homemade":
                    bakingdModifier = 1.0;
                    break;
            }

            var calories = (baseCalories * this.Weight) * flourModifier * bakingdModifier;

            return calories ;
        }
    }
}
