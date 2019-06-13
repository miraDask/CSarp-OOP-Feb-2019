namespace P07_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();
            Person mainPerson = new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }

            familyTree.Add(mainPerson);

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");

                if (tokens.Length > 1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];

                    Person currentPerson;

                    if (IsBirthday(firstPerson))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Birthday = firstPerson;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Name = firstPerson;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (person == null)
                    {
                        person = new Person();
                        familyTree.Add(person);
                    }

                    person.Name = name;
                    person.Birthday = birthday;

                    int index = familyTree.IndexOf(person) + 1;
                    int count = familyTree.Count - index;

                    Person[] copy = new Person[count];

                    for (int i = 0; i < familyTree.Count; i++)
                    {
                        if (familyTree[i].Name == person.Name)
                        {
                            familyTree[i].Birthday = person.Birthday;
                        }
                    }

                    familyTree.CopyTo(index, copy, 0, count);

                    Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (copyPerson != null)
                    {
                        familyTree.Remove(copyPerson);
                        person.Parents.AddRange(copyPerson.Parents);
                        person.Parents = person.Parents.Distinct().ToList();

                        person.Children.AddRange(copyPerson.Children);
                        person.Children = person.Children.Distinct().ToList();
                    }
                }
            }

            Console.WriteLine(string.Join("", mainPerson));

        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string childInfo)
        {
            var childPerson = new Person();

            if (IsBirthday(childInfo))
            {
                if (!familyTree.Any(p => p.Birthday == childInfo))
                {
                    childPerson.Birthday = childInfo;
                    familyTree.Add(childPerson);
                }
                else
                {
                    childPerson = familyTree.First(p => p.Birthday == childInfo);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == childInfo))
                {
                    childPerson.Name = childInfo;
                    familyTree.Add(childPerson);
                }
                else
                {
                    childPerson = familyTree.First(p => p.Name == childInfo);
                }
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
            
        }

        static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
