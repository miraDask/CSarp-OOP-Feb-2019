namespace P03.WildFarm.Factories
{
    using Models.Animals;
    using Models.Animals.Birds;
    using Models.Animals.Mammals;

    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string[] args)
        {
            string animalType = args[0];
            string name = args[1];
            double weigth = double.Parse(args[2]);
            
            switch (animalType)
            {
                case "Hen":
                case "Owl":

                    double wingSize = double.Parse(args[3]);
                    if (animalType == "Hen")
                    {
                        return new Hen(name,weigth,wingSize);
                    }
                    else
                    {
                        return new Owl(name, weigth, wingSize);
                    }

                case "Mouse":
                case "Dog":

                    string livingRegion = args[3];

                    if (animalType == "Dog")
                    {
                        return new Dog(name, weigth, livingRegion);
                    }
                    else
                    {
                        return new Mouse(name, weigth, livingRegion);
                    }

                case "Cat":
                case "Tiger":

                    string felinesLivingRegion = args[3];
                    string breed = args[4];

                    if (animalType == "Cat")
                    {
                        return new Cat(name, weigth, felinesLivingRegion, breed);
                    }
                    else
                    {
                        return new Tiger(name, weigth, felinesLivingRegion, breed);
                    }

                default:
                    return null;
            }
        }
    }
}
