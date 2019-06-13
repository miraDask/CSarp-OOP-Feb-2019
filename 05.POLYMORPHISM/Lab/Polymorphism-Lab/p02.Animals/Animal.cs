namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name { get; private set; }

        public string FavouriteFood { get; private set; }

        public string FavouriteFood1 { get; }

        public string Name1 { get; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name1} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
