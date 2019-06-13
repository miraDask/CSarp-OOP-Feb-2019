namespace StorageMester.Tests.Structure.FactoriesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Factories;
    using System;

    [TestFixture]
    public class VehicleFactoryTests
    {
        private const string InvalidTypeOfVehicle = "car";
        private VehicleFactory vehicleFactory;

        [SetUp]
        public void SetUp()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        [Test]
        public void VehicleFactory_ThrowsInvalidOperationException_WhenInvalidTypeOfVehicle_IsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => this.vehicleFactory.CreateVehicle(InvalidTypeOfVehicle));
        }

        [Test]
        [TestCase("Semi")]
        [TestCase("Truck")]
        [TestCase("Van")]
        public void VehicleFactory_CreatesVehicle_Successfully(string type)
        {
            var vehicle = this.vehicleFactory.CreateVehicle(type);

            Assert.AreEqual(type, vehicle.GetType().Name);
        }
    }
}
