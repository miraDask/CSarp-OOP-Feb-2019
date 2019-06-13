namespace P02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double wastedFuel = 0.05;
        private const double airconditionConsumption = 1.6;

        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption + airconditionConsumption)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= (fuel * wastedFuel);
        }
    }
}
