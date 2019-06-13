namespace p07.FoodShortage
{
    public class Citizen : Person ,IIdentifiable, IBirthable
    {
        private const int ValueToIncreaseFood = 10;

        public Citizen(string name, string age, string id, string birthdate)
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public override void BuyFood()
        {
            this.Food += ValueToIncreaseFood;
        }
    }
}
