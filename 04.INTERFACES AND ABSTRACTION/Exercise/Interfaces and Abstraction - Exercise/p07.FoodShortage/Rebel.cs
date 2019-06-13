namespace p07.FoodShortage
{
    public class Rebel : Person
    {
        private const int ValueToIncreaseFood = 5;
        private string rebelGroup;

        public Rebel(string name, string age, string rebelGroup) : base(name,age)
        {
            this.rebelGroup = rebelGroup;
        }

        public override void BuyFood()
        {
            this.Food += ValueToIncreaseFood;
        }
    }
}
