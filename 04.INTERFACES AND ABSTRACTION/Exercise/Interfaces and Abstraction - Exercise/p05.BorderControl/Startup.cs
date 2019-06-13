namespace p05.BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];

                    Robot robot = new Robot(model, id);
                    identifiables.Add(robot);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    string age = input[1];
                    string id = input[2];

                    Citizen citizen = new Citizen(name,age,id);
                    identifiables.Add(citizen);
                }
            }

            string finalSymbolsOfFakeId = Console.ReadLine();

            foreach (IIdentifiable identible in identifiables)
            {
                if (identible.Id.EndsWith(finalSymbolsOfFakeId))
                {
                    Console.WriteLine(identible.Id);
                }
            }
        }
    }
}
