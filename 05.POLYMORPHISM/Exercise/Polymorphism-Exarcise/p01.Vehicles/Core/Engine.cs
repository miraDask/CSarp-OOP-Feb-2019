namespace Vehicles
{
    using System;

    public class Engine
    {
        private static Vehicle car;
        private static Vehicle truck;

        public void Run()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();

            car = vehicleFactory.CreateVehicle(carData);
            truck = vehicleFactory.CreateVehicle(truckData);

            int commandsLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsLines; i++)
            {
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                string typeOfVehicle = commandLine[1];
                Vehicle currentVehicle = ChooseVehicle(typeOfVehicle);

                if (command == "Drive")
                {
                    double distanse = double.Parse(commandLine[2]);
                    Console.WriteLine(currentVehicle.Drive(distanse));
                }
                else
                {
                    double fuel = double.Parse(commandLine[2]);
                    currentVehicle.Refuel(fuel);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Vehicle ChooseVehicle(string typeOfVehicle)
        {
            if (typeOfVehicle == "Car")
            {
                return car;
            }
            else
            {
                return truck;
            }
        }
    }
}
