namespace p05.MordorsCruelPlan.Core
{
    using p05.MordorsCruelPlan.Factories;
    using p05.MordorsCruelPlan.Foods;
    using p05.MordorsCruelPlan.Moods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            FoodFactory foodFactory = new FoodFactory();
            MoodFactory moodFactory = new MoodFactory();
            List<Food> foodCollection = new List<Food>();

            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var food = foodFactory.CreateNewFood(input[i]);
                foodCollection.Add(food);
            }

            int totalHappinessPoints = foodCollection.Sum(x => x.HappinesPoints);
            var mood = moodFactory.CreateNewMood(totalHappinessPoints);
            string moodType = mood.Name;

            Console.WriteLine(totalHappinessPoints);
            Console.WriteLine(moodType);
        }
    }
}
