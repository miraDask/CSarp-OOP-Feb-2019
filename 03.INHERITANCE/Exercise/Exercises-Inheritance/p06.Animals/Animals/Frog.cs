namespace p06.Animals.Animals
{
    public class Frog : Animal
    {
        public Frog(string name, string age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
