namespace StorageMester.Tests.Structure.VehiclesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Linq;

    [TestFixture]
    public class VanTests
    {
        private const int Capacity = 2;
        private const double InitialProductPrice = 100;
        private Vehicle van;

        [SetUp]
        public void SetUp()
        {
            this.van = new Van();
        }

        [Test]
        public void Constructor_Creates_CorrectVehicle()
        {
            Assert.IsNotNull(this.van);
            Assert.AreEqual(Capacity, this.van.Capacity);
        }

        [Test]
        public void CapacityProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(Capacity, this.van.Capacity);
        }

        [Test]
        public void TrunkProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(false, this.van.Trunk.Any());
        }

        [Test]
        public void IsEmptyProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(true, this.van.IsEmpty);
        }

        [Test]
        public void LoadProduct_Correctly()
        {
            var product = new HardDrive(InitialProductPrice);

            this.van.LoadProduct(product);
            var expectedLoadedProductsCount = 1;

            Assert.AreEqual(expectedLoadedProductsCount, this.van.Trunk.Count);
        }

        [Test]
        public void IsFullProperty_Gets_CorrectValue()
        {
            var product = new HardDrive(InitialProductPrice);  // hardDrive.Weight == 1;

            for (int i = 0; i < Capacity; i++)
            {
                this.van.LoadProduct(product);
            }

            Assert.AreEqual(true, this.van.IsFull);
        }

        [Test]
        public void LoadProduct_ThrowInvalidOperationException_WhenTrunkIsFull()
        {
            var product = new HardDrive(InitialProductPrice);  // hardDrive.Weight == 1;

            for (int i = 0; i < Capacity; i++)
            {
                this.van.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }

        [Test]
        public void Unload_EmptyVehicle_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void Unload_LastAddedProduct()
        {
            var firstProduct = new HardDrive(InitialProductPrice);  
            var secondProduct = new Ram(InitialProductPrice);  
            var lastProduct = new SolidStateDrive(InitialProductPrice);

            van.LoadProduct(firstProduct);
            van.LoadProduct(secondProduct);
            van.LoadProduct(lastProduct);

            var expectedUnloededProduct = van.Unload();

            Assert.AreSame(expectedUnloededProduct, lastProduct);
        }
    }
}
