namespace p06.Animals.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, string age)
          : base(name, age, "Male")
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
