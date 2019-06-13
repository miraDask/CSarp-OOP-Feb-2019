namespace P03.WildFarm.Models.Animals.Mammals
{
    using Contracts;
    using System.Text;

    public class Tiger : Feline, IMeetEater
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
