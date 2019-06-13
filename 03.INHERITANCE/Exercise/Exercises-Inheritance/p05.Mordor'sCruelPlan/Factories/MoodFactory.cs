namespace p05.MordorsCruelPlan.Factories
{
    using p05.MordorsCruelPlan.Moods;

    public class MoodFactory
    {
        public Mood CreateNewMood(int happinessPoints)
        {
            if (happinessPoints < -5)
            {
                return new Angry();
            }
            else if (happinessPoints >= -5 && happinessPoints <= 0)
            {
                return new Sad();
            }
            else if (happinessPoints >= 1 && happinessPoints <= 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }
    }
}
