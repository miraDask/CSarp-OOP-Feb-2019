using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models
{
    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            FillGarage(vehicles);
            this.products = new List<Product>();
        }

        public string Name { get; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = this.GetVehicle(garageSlot);

            int slot = Array.IndexOf(deliveryLocation.garage, null);

            if (slot == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            deliveryLocation.garage[slot] = vehicle;

            return slot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = this.GetVehicle(garageSlot);

            int countOfUnloadedProducts = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                var product = vehicle.Unload();
                this.products.Add(product);
                countOfUnloadedProducts++;
            }

            return countOfUnloadedProducts;
        }

        private void FillGarage(IEnumerable<Vehicle> vehicles)
        {
            this.garage = new Vehicle[GarageSlots];
            int index = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[index] = vehicle;
                index++;
            }
        }
    }
}
