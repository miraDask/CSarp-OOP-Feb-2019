namespace p03.Ferrari
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string Model => "488-Spider";

        public string DriverName { get; private set; }

        public string PushTheGasPedal()
        {
           return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGasPedal()}/{this.DriverName}";
        }
    }
}
