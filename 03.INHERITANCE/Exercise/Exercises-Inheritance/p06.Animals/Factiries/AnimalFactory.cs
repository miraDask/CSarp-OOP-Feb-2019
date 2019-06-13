namespace p06.Animals.Factiries
{
    using p06.Animals.Animals;
    using System;

    public class AnimalFactory
    {
        public Animal CreateAnimal(string animalKind, string name, string age , string gender)
        {
            switch (animalKind.ToLower())
            {
                case "dog":
                    return new Dog(name,age,gender);
                case "frog":
                    return new Frog(name, age, gender); ;
                case "cat":
                    return new Cat(name, age, gender); ;
                case "kitten":
                    return new Kitten(name, age); ;
                case "tomcat":
                    return new Tomcat(name, age); ;
                default:
                    throw new FormatException("Invalid input!");
            }
        }
    }
}
