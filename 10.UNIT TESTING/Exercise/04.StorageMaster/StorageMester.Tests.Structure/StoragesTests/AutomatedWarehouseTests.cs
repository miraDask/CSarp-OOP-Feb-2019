namespace StorageMester.Tests.Structure.StoragesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class AutomatedWarehouseTests
    {
        private const string StorageName = "CurrentStorage";
        private const int Capacity = 1;
        private const int GarageSlots = 2;
        private Storage automatedWarehouse;
        private static Vehicle[] defaultVehicles = GetDefaultVehicles();
        private static readonly Vehicle[] initialGarage = GetInitialGarage();

        [SetUp]
        public void SetUp()
        {
            this.automatedWarehouse = new AutomatedWarehouse(StorageName);
        }

        [Test]
        public void Constructor_Creates_CorrectStorage()
        {
            var garage = GetGarageCollection();

            var products = GetProductCollection();

            var expectedGarageCapacity = GarageSlots;
            var expectedCountOfProducts = 0;

            Assert.IsNotNull(this.automatedWarehouse);
            Assert.AreEqual(expectedGarageCapacity, garage.Length);
            Assert.AreEqual(expectedCountOfProducts, products.Count);
        }

        [Test]
        public void NameProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(StorageName, this.automatedWarehouse.Name);
        }

        [Test]
        public void CapacityProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(Capacity, this.automatedWarehouse.Capacity);
        }

        [Test]
        public void GarageSlotsProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(GarageSlots, this.automatedWarehouse.GarageSlots);
        }

        [Test]
        public void IsFullProperty_Gets_CorrectValue()
        {
            Vehicle vehicle = new Truck();
            FillStorageCapacityByAddingNewTruck(vehicle);
            this.automatedWarehouse.UnloadVehicle(1);

            var products = GetProductCollection();
            var productsWeight = products.Sum(x => x.Weight);
            var expectedWeight = Capacity;

            Assert.AreEqual(expectedWeight, productsWeight);
            Assert.AreEqual(true, this.automatedWarehouse.IsFull);
        }

        [Test]
        public void GarageProperty_Gets_CorrectValue()
        {
            var garage = GetGarageCollection();

            CollectionAssert.AreEqual(garage, this.automatedWarehouse.Garage);
        }

        [Test]
        public void ProductsProperty_Gets_CorrectValue()
        {
            var products = GetProductCollection();

            CollectionAssert.AreEqual(products, this.automatedWarehouse.Products);
        }

        [Test]
        [TestCase(10)] // GarageSlots
        [TestCase(11)] // GarageSlots + 1
        public void GetVehicle_FromInvalidSlot_ThrowsInvalidOperationException(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(3)] // count Of defaultVehicles
        [TestCase(9)] // last possible index -> GarageSlots - 1
        public void GetVehicle_WhichIsNull_ThrowsInvalidOperationException(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(0)]
        public void GetVehicle_Returns_CorrectVehicle(int garageSlot)
        {
            var expectedVehicle = initialGarage[garageSlot];

            var garage = GetGarageCollection();

            var targetVehicle = garage[garageSlot];

            Assert.AreEqual(expectedVehicle, targetVehicle);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void SendVehicleTo_Location_WhichHasNoFreeSlotInGarage_ThrowsInvalidOperationException(int garageSlot)
        {
            Storage deliveryLocation = new AutomatedWarehouse(name: "DeliveryLocation");

            var type = typeof(Storage);

            InvokeAddMethod(type, new Truck(), deliveryLocation);

            Assert.Throws<InvalidOperationException>(()
                => this.automatedWarehouse.SendVehicleTo(garageSlot, deliveryLocation));
        }

        [Test]
        public void SendVehicleTo_Returns_AddedGarageSlotIndex_Correctly()
        {
            Storage deliveryLocation = new Warehouse(name: "DeliveryLocation");

            var type = typeof(Storage);

            InvokeAddMethod(type, new Truck(), deliveryLocation);

            var expectedIndexOfAddedSlot = 3;
            var indexOfAddedSlot = Array
                .IndexOf(deliveryLocation.Garage.ToArray()
                , deliveryLocation.Garage.Last(x => x != null));

            Assert.AreEqual(expectedIndexOfAddedSlot, indexOfAddedSlot);
        }

        [Test]
        public void SendVehicleTo_SetToNull_GarageSlot_FromWhereSendsVehicle()
        {
            Storage deliveryLocation = new Warehouse(name: "DeliveryLocation");

            this.automatedWarehouse.SendVehicleTo(0, deliveryLocation);

            Vehicle expectedResult = null;
            Vehicle vehicleAtFirstIndexOfGarage = deliveryLocation.Garage.First(x => x == null);

            Assert.AreEqual(expectedResult, vehicleAtFirstIndexOfGarage);
        }

        [Test]
        public void UnloadVehicle_Successfully()
        {
            var products = GetProductCollection();
            var productsWeight = products.Sum(x => x.Weight);

            this.automatedWarehouse.UnloadVehicle(0);

            var expectedWeight = 0; // initial vehicle is Empty

            Assert.AreEqual(expectedWeight, productsWeight);
        }

        [Test]
        public void UnloadVehicle_WhenStorageIsFull_ThrowInvalidOperationException()
        {
            Vehicle vehicle = new Truck();
            FillStorageCapacityByAddingNewTruck(vehicle);
            this.automatedWarehouse.UnloadVehicle(1);

            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.UnloadVehicle(2));
        }

        [Test]
        public void AddVehicle_Successfully()
        {
            Vehicle vehicle = new Truck();
            FillStorageCapacityByAddingNewTruck(vehicle);

            initialGarage[1] = vehicle;
            var garage = GetGarageCollection();

            CollectionAssert.AreEquivalent(initialGarage, garage);
        }

        private void InvokeAddMethod(Type type, Vehicle vehicle, Storage invokationTarget)
        {

            var addMethod = type
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "AddVehicle");

            addMethod.Invoke(invokationTarget, new object[] { vehicle });
        }

        private void LoadVehicle(Vehicle vehicle, Product product)
        {
            vehicle.LoadProduct(product);
        }

        private static Vehicle[] GetDefaultVehicles()
        {
            var type = typeof(AutomatedWarehouse);

            var defaultVehicles = (Vehicle[])type
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)
            .FirstOrDefault(x => x.Name == "DefaultVehicles")
            .GetValue(type);

            return defaultVehicles;
        }

        private static Vehicle[] GetInitialGarage()
        {
            var initialGarage = new Vehicle[GarageSlots];

            for (int i = 0; i < defaultVehicles.Length; i++)
            {
                initialGarage[i] = defaultVehicles[i];
            }

            return initialGarage;
        }

        private Vehicle[] GetGarageCollection()
        {
            var type = typeof(Storage);

            var fields = type.
             GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            return (Vehicle[])fields
                .FirstOrDefault(x => x.Name == "garage")
                .GetValue(this.automatedWarehouse);
        }

        private List<Product> GetProductCollection()
        {
            var type = typeof(Storage);

            var fields = type.
             GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            return (List<Product>)fields
                 .FirstOrDefault(x => x.Name == "products")
                 .GetValue(this.automatedWarehouse);
        }

        private void FillStorageCapacityByAddingNewTruck(Vehicle vehicle)
        {
            Product product = new HardDrive(price: 100);
            LoadVehicle(vehicle, product);

            var type = typeof(Storage);

            InvokeAddMethod(type, vehicle, this.automatedWarehouse);
        }
    }
}
