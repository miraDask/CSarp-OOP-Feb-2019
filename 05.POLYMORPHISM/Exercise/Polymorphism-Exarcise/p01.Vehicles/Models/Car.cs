namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionIncreasment = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity,fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + fuelConsumptionIncreasment;
        }
    }
}
