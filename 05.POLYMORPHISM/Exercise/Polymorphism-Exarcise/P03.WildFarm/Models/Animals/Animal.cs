namespace P03.WildFarm.Models.Animals
{
    using Contracts;
    using DataValidators;
    using Models.Food;

    public abstract class Animal : ISoundProducable
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; private set; }

        public void Eat(Food food)
        {
            string foodType = food.GetType().Name;

            FoodValidator.Validate(foodType, this);

            this.Weight += food.Quantity * WeightInsreasment.Values[this.GetType().Name];
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();
        
    }
}
