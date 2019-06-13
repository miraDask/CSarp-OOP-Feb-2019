namespace StorageMester.Tests.Structure.VehiclesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Linq;

    [TestFixture]
    public class TruckTests
    {
        private const int Capacity = 5;
        private const double InitialProductPrice = 100;
        private Vehicle truck;

        [SetUp]
        public void SetUp()
        {
            this.truck = new Truck();
        }

        [Test]
        public void Constructor_Creates_CorrectVehicle()
        {
            Assert.IsNotNull(this.truck);
            Assert.AreEqual(Capacity, this.truck.Capacity);
        }

        [Test]
        public void CapacityProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(Capacity, this.truck.Capacity);
        }

        [Test]
        public void TrunkProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(false, this.truck.Trunk.Any());
        }

        [Test]
        public void IsEmptyProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(true, this.truck.IsEmpty);
        }

        [Test]
        public void LoadProduct_Correctly()
        {
            var product = new HardDrive(InitialProductPrice);

            this.truck.LoadProduct(product);
            var expectedLoadedProductsCount = 1;

            Assert.AreEqual(expectedLoadedProductsCount, this.truck.Trunk.Count);
        }

        [Test]
        public void IsFullProperty_Gets_CorrectValue()
        {
            var product = new HardDrive(InitialProductPrice);  // hardDrive.Weight == 1;

            for (int i = 0; i < Capacity; i++)
            {
                this.truck.LoadProduct(product);
            }

            Assert.AreEqual(true, this.truck.IsFull);
        }

        [Test]
        public void LoadProduct_ThrowInvalidOperationException_WhenTrunkIsFull()
        {
            var product = new HardDrive(InitialProductPrice);  // hardDrive.Weight == 1;

            for (int i = 0; i < Capacity; i++)
            {
                this.truck.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => this.truck.LoadProduct(product));
        }

        [Test]
        public void Unload_EmptyVehicle_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.truck.Unload());
        }

        [Test]
        public void Unload_LastAddedProduct()
        {
            var firstProduct = new HardDrive(InitialProductPrice);
            var secondProduct = new Ram(InitialProductPrice);
            var lastProduct = new SolidStateDrive(InitialProductPrice);

            truck.LoadProduct(firstProduct);
            truck.LoadProduct(secondProduct);
            truck.LoadProduct(lastProduct);

            var expectedUnloededProduct = truck.Unload();

            Assert.AreSame(expectedUnloededProduct, lastProduct);
        }
    }
}
