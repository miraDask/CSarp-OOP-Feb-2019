﻿namespace P02.VehiclesExtension
{
    using System;

    public class Engine
    {
        private static Vehicle car;
        private static Vehicle truck;
        private static Vehicle bus;

        public void Run()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();
            string[] busData = Console.ReadLine().Split();

            car = vehicleFactory.CreateVehicle(carData);
            truck = vehicleFactory.CreateVehicle(truckData);
            bus = vehicleFactory.CreateVehicle(busData);

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
                else if (command == "Refuel")
                {
                    try
                    {
                        double fuel = double.Parse(commandLine[2]);
                        currentVehicle.Refuel(fuel);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else
                {
                    Bus currentBus = (Bus)currentVehicle;
                    double distanse = double.Parse(commandLine[2]);
                    Console.WriteLine(currentBus.DriveEmpty(distanse));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Vehicle ChooseVehicle(string typeOfVehicle)
        {
            if (typeOfVehicle == "Car")
            {
                return car;
            }
            else if (typeOfVehicle == "Truck")
            {
                return truck;
            }
            else
            {
                return bus;
            }
        }
    }
}
