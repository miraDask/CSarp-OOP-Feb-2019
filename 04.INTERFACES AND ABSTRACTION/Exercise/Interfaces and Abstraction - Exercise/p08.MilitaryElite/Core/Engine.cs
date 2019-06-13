namespace p08.MilitaryElite.Core
{
    using p08.MilitaryElite.Factories;
    using p08.MilitaryElite.Interfaces;
    using p08.MilitaryElite.Soldiers;
    using System;

    public class Engine
    {
        public void Run()
        {
            Army army = new Army();
            SoldierFactory soldierFactory = new SoldierFactory();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                ISoldier soldier = soldierFactory.CreateSoldier(input, army);

                if (soldier == null)
                {
                    continue;
                }

                army.AddSoldier(soldier);
            }

            foreach (var soldier in army)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
