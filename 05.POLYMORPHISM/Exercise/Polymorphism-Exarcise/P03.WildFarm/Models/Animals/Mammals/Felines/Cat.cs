namespace P03.WildFarm.Models.Animals.Mammals
{
    using System.Text;
    using Contracts;

    public class Cat : Feline, IMeetEater,IVegitableEater 
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
