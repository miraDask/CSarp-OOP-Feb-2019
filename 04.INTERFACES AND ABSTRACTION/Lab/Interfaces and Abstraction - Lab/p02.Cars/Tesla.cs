namespace Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int batteries) : base(model, color)
        {
            this.Batteries = batteries;
        }

        public int Batteries { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Batteries} Batteries");
            result.Append(base.ToString());

            return result.ToString();
        }
    }
}
