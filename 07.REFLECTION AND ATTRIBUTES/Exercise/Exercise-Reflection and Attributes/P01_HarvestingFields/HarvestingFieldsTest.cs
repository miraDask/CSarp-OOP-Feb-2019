 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "HARVEST")
                {
                    break;
                }

                Type classType = typeof(HarvestingFields);
                FieldInfo[] currentFieldCollection = GetCollectionOfFieldsOfCurrentType(classType, input);

                if (currentFieldCollection == null)
                {
                    continue;
                }

                foreach (FieldInfo field in currentFieldCollection)
                {
                    string[] accessModifiers = new string[] {"public", "private", "protected" };
                    string accessModifier = field.IsPublic ?
                        accessModifiers[0] : field.IsPrivate ?
                        accessModifiers[1] : accessModifiers[2];

                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }

            }
        }

        private static FieldInfo[] GetCollectionOfFieldsOfCurrentType(Type classType, string input)
        {
            switch (input)
            {
                case "private":
                    return classType
                        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                        .Where(x => x.IsPrivate)
                        .ToArray();

                case "protected":
                    return classType
                        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                        .Where(x => x.IsFamily)
                        .ToArray();

                case "public":
                    return classType
                       .GetFields(BindingFlags.Instance | BindingFlags.Public)
                       .Where(x => x.IsPublic)
                       .ToArray();

                case "all":
                    return classType
                       .GetFields(BindingFlags.Instance
                       | BindingFlags.Static
                       | BindingFlags.NonPublic
                       | BindingFlags.Public);
                       
                default:
                    return null;
            }
        }
    }
}
