namespace P03.WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Mouse : Mammal, IVegitableEater, IFruitEater
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
