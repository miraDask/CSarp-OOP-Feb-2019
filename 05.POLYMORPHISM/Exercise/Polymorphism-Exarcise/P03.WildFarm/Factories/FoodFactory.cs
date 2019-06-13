namespace P03.WildFarm.Factories
{
    using P03.WildFarm.Models.Food;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class FoodFactory
    {
        public static Food CreateFood(string[] args)
        {
            string foodtype = args[0];
            int quantity = int.Parse(args[1]);

            switch (foodtype)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    return null;
            }
        }
    }
}
