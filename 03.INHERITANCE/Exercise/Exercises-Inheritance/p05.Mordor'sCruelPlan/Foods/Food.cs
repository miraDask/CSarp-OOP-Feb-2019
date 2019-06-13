namespace p05.MordorsCruelPlan.Foods
{
    public abstract class Food
    {
        public Food(int happinessPoints)
        {
            this.HappinesPoints = happinessPoints;
        }

        public int HappinesPoints { get; }
    }
}
