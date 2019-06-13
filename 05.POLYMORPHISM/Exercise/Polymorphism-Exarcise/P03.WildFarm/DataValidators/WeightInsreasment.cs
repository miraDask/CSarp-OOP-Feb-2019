namespace P03.WildFarm.DataValidators
{
    using System.Collections.Generic;

    public static class WeightInsreasment
    {
        public static readonly Dictionary<string, double> Values = new Dictionary<string, double>()
                {
                    { "Hen" , 0.35},
                    { "Owl", 0.25},
                    { "Mouse" , 0.10},
                    { "Cat" , 0.30},
                    { "Dog", 0.40},
                    { "Tiger",1.00}

                };
    }
}


