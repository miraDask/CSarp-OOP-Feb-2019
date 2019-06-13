namespace P03.WildFarm.DataValidators
{
    using Contracts;
    using Models.Animals;
    using System;

    public static class FoodValidator
    {
        public static void Validate(string foodType, Animal animal)
        {
            try
            {
                switch (foodType)
                {
                    case "Vegetable":
                        var vagitableEater = (IVegitableEater)animal;
                        break;
                    case "Fruit":
                        var fruitEater = (IFruitEater)animal;
                        break;
                    case "Meat":
                        var meatEater = (IMeetEater)animal;
                        break;
                    case "Seeds":
                        var seedsEater = (ISeedsEater)animal;
                        break;
                }
            }
            catch (Exception)
            {

                throw new ArgumentException($"{animal.GetType().Name} does not eat {foodType}!");
            }
        }
    }
}
