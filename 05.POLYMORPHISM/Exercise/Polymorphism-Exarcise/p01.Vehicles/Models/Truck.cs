namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncreasment = 1.6;
        private const double fuelQuantityDecreasment = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption += fuelConsumptionIncreasment;
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * fuelQuantityDecreasment);
        }
    }
}
