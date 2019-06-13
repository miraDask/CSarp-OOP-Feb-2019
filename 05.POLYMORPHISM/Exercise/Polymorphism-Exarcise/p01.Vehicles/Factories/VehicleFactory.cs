namespace Vehicles
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string[] data)
        {
            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);

            if (type == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption);
            }
            else
            {
                return new Truck(fuelQuantity, fuelConsumption);
            }
        }
    }
}
