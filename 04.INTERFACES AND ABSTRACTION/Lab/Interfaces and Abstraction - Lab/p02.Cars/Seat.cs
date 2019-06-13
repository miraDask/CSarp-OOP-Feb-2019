using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color) : base(model, color)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
            result.Append(base.ToString());
            
            return result.ToString();
        }
    }
}
