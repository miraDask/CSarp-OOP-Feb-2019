namespace P02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double airconditionConsumption = 0.9;

        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption + airconditionConsumption)
        {
        }
    }
}
