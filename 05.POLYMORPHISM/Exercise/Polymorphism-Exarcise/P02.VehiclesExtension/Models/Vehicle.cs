namespace P02.VehiclesExtension
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;

            this.FuelQuantity = fuelQuantity;

            this.FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.FuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; protected set; }

        public double DrivenDistance { get; private set; } = 0;

        public string Drive(double distance)
        {
            string typeOfVehicle = this.GetType().Name;
            double fuelNeededForTheTrip = distance * this.FuelConsumption;

            if (this.FuelQuantity >= fuelNeededForTheTrip)
            {
                this.FuelQuantity -= fuelNeededForTheTrip;
                this.DrivenDistance += distance;

                return $"{typeOfVehicle} travelled {distance} km";
            }

            return $"{typeOfVehicle} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {

            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
