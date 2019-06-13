namespace P03.WildFarm.Models.Animals.Mammals
{
    using Contracts;
    using System.Text;

    public class Dog : Mammal, IMeetEater
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
