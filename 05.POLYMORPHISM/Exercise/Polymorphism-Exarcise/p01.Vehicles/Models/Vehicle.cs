namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption; // liter per km

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double DrivenDistence { get; private set; } = 0;

        public string Drive(double distance)
        {
            double fuelNeededForTheTrip = distance * this.FuelConsumption;

            if (this.FuelQuantity >= fuelNeededForTheTrip)
            {
                this.FuelQuantity -= fuelNeededForTheTrip;
                this.DrivenDistence += distance;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
