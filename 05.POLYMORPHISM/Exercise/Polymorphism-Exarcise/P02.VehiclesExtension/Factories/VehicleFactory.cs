namespace P02.VehiclesExtension
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string[] data)
        {
            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            double tankCapacity = double.Parse(data[3]);

            if (type == "Car")
            {
                return new Car(tankCapacity,fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                return new Truck(tankCapacity,fuelQuantity, fuelConsumption);
            }
            else
            {
                return new Bus(tankCapacity, fuelQuantity, fuelConsumption);
            }
        }
    }
}
