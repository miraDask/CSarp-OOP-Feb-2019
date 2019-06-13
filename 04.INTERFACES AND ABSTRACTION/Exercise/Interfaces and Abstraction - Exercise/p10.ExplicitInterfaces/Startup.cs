namespace p10.ExplicitInterfaces
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            while (true)
            {
                string[] citizenData = Console.ReadLine().Split();

                if (citizenData[0] == "End")
                {
                    break;
                }

                string name = citizenData[0];
                string country = citizenData[1];
                int age = int.Parse(citizenData[2]);

                IPerson person = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());

                IResident resident = (IResident)person;

                Console.WriteLine(resident.GetName());

            }
        }
    }
}
