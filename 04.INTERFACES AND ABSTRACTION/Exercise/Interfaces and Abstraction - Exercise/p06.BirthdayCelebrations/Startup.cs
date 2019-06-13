namespace p06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                IBirthable currentType = GenerateITypeble(input);

                if (currentType == null)
                {
                    continue;
                }

                birthables.Add(currentType);
            }

            string year = Console.ReadLine();

            List<string> birthdates = birthables
                .Where(x => x.Birthdate.EndsWith(year))
                .Select(x => x.Birthdate)
                .ToList();

            if (birthdates.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, birthdates));
            }
        }

        private static IBirthable GenerateITypeble(string[] input)
        {
            string type = input[0];
            string name = input[1];
            string birthdate = string.Empty;

            switch (type.ToLower())
            {
                case "pet":
                    
                    birthdate = input[2];

                    return new Pet(name, birthdate);

                case "citizen":

                    string age = input[2];
                    string id = input[3];
                    birthdate = input[4];

                    return new Citizen(name, age, id, birthdate);
            }

            return null;
        }
    }
}
