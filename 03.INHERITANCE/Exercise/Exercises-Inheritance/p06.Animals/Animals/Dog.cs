namespace p06.Animals.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string age, string gender)
            : base(name,age,gender)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
