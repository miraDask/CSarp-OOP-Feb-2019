namespace P03.WildFarm.Models.Animals.Birds
{
    using P03.WildFarm.Contracts;

    public class Hen : Bird, IMeetEater,IFruitEater,ISeedsEater,IVegitableEater
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
           return "Cluck";
        }
    }
}
