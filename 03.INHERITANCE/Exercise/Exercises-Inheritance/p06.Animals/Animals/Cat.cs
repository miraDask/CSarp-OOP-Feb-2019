namespace p06.Animals.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string age, string gender)
           : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }
}
