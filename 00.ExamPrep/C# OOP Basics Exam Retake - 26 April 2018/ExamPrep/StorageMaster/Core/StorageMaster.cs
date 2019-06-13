using StorageMaster.Models;
using StorageMaster.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Storage> storageRegistry;
        private Dictionary<string, List<Product>> productsPool;
        private Vehicle currentVehicle;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.storageRegistry = new Dictionary<string, Storage>();
            this.productsPool = new Dictionary<string, List<Product>>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.GetProduct(type, price);

            if (product == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            if (!productsPool.ContainsKey(type))
            {
                this.productsPool[type] = new List<Product>();
            }

            this.productsPool[type].Add(product);

            return "Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.GetStorage(type, name);

            if (storage == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            this.storageRegistry[type] = storage;

            return $"Registered {storage.GetType().Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";

        }

        //TODO NOT SURE
        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProducts = 0;

            while (!this.currentVehicle.IsFull)
            {
                foreach (var name in productNames)
                {

                    if (this.productsPool.Count == 0 || productsPool[name].Count == 0)
                    {
                        throw new InvalidOperationException($"{name} is out of stock!");
                    }

                    var product = this.productsPool[name].Last();
                    this.productsPool[name].Remove(product);
                    this.currentVehicle.LoadProduct(product);

                    loadedProducts++;
                }
            }

            return $"Loaded {loadedProducts}/{productNames.Count()} products into {currentVehicle.GetType().Name}";

        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var sourceStorage = this.storageRegistry[sourceName];
            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            var destinationStorage = this.storageRegistry[destinationName];
            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            
            return $"Unloaded {unloadedProductsCount}/{vehicle.Trunk.Count} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry[storageName];

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            var sortedStorage = this.storageRegistry.Values
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToArray();

            foreach (var storage in sortedStorage)
            {
                sb.AppendLine($"{storage.Name}:");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }

    }
}
