namespace StorageMester.Tests.Structure.FactoriesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Factories;
    using System;

    [TestFixture]
    public class ProductFactoryTests
    {

        private const string InvalidTypeOfProduct = "box";
        private const double Price = 123;
        private ProductFactory productFactory;

        [SetUp]
        public void SetUp()
        {
            this.productFactory = new ProductFactory();
        }

        [Test]
        public void VehicleFactory_ThrowsInvalidOperationException_WhenInvalidTypeOfFactory_IsPassed()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.productFactory.CreateProduct(InvalidTypeOfProduct, Price));
        }

        [Test]
        [TestCase("Gpu")]
        [TestCase("Ram")]
        [TestCase("HardDrive")]
        [TestCase("SolidStateDrive")]
        public void VehicleFactory_CreatesVehicle_Successfully(string type)
        {
            var vehicle = this.productFactory.CreateProduct(type, Price);

            Assert.AreEqual(type, vehicle.GetType().Name);
        }
    }
}
