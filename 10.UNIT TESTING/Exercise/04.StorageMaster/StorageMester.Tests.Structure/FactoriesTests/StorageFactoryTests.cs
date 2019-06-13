namespace StorageMester.Tests.Structure.FactoriesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Factories;
    using System;

    [TestFixture]
    public class StorageFactoryTests
    {

        private const string InvalidTypeOfStorage = "box";
        private const string Name = "currentStorage";
        private StorageFactory storageFactory;

        [SetUp]
        public void SetUp()
        {
            this.storageFactory = new StorageFactory();
        }

        [Test]
        public void VehicleFactory_ThrowsInvalidOperationException_WhenInvalidTypeOfFactory_IsPassed()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.storageFactory.CreateStorage(InvalidTypeOfStorage, Name));
        }

        [Test]
        [TestCase("Warehouse")]
        [TestCase("DistributionCenter")]
        [TestCase("AutomatedWarehouse")]
        public void VehicleFactory_CreatesVehicle_Successfully(string type)
        {
            var vehicle = this.storageFactory.CreateStorage(type, Name);

            Assert.AreEqual(type, vehicle.GetType().Name);
        }
    }
}
