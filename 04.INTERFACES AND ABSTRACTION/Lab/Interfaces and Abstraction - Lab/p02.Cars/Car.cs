namespace Cars
{
    using System.Text;

    public abstract class Car : ICar
    {

        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        protected string Model { get; private set; }

        protected string Color { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            
            result.AppendLine(this.Start());
            result.Append(this.Stop());

            return result.ToString();
        }
    }
}
