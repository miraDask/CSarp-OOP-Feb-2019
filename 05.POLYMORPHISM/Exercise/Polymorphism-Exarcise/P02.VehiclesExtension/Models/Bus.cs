namespace P02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double airconditionConsumption = 1.4;

        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption) 
            : base(tankCapacity, fuelQuantity, fuelConsumption + airconditionConsumption)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= airconditionConsumption;
            return base.Drive(distance);
        }
    }
}
