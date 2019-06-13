namespace P03.WildFarm.Models.Animals.Birds
{
    using Contracts;

    public class Owl : Bird, IMeetEater
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
