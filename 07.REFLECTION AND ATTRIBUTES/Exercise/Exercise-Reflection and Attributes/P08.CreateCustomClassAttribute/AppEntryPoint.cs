namespace P07.InfernoInfinity
{
    using P07.InfernoInfinity.Models.CustomAttributes;
    using P07.InfernoInfinity.Models.Weapons;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AppEntryPoint
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                WriteInfo(input);
            }
        }

        private static void WriteInfo(string input)
        {
            Type classType = Assembly
                 .GetExecutingAssembly()
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == nameof(Weapon));

            var attribute = (ClassInfoAttribute)classType.GetCustomAttribute(typeof(ClassInfoAttribute));

            switch (input)
            {
                case "Author":
                    Console.WriteLine($"Author: {attribute.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attribute.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attribute.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ",attribute.Reviewers)}");
                    break;
            }
        }
    }
}
