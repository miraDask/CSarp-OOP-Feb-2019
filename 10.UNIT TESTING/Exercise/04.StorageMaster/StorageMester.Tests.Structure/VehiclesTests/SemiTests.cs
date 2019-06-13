namespace StorageMester.Tests.Structure.VehiclesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Linq;

    [TestFixture]
    public class SemiTests
    {
        private const int Capacity = 10;
        private const double InitialProductPrice = 100;
        private Vehicle semi;

        [SetUp]
        public void SetUp()
        {
            this.semi = new Semi();
        }

        [Test]
        public void Constructor_Creates_CorrectVehicle()
        {
            Assert.IsNotNull(this.semi);
            Assert.AreEqual(Capacity, this.semi.Capacity);
        }

        [Test]
        public void CapacityProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(Capacity, this.semi.Capacity);
        }

        [Test]
        public void TrunkProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(false, this.semi.Trunk.Any());
        }

        [Test]
        public void IsEmptyProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(true, this.semi.IsEmpty);
        }

        [Test]
        public void LoadProduct_Correctly()
        {
            var product = new HardDrive(InitialProductPrice);

            this.semi.LoadProduct(product);
            var expectedLoadedProductsCount = 1;

            Assert.AreEqual(expectedLoadedProductsCount, this.semi.Trunk.Count);
        }

        [Test]
        public void IsFullProperty_Gets_CorrectValue()
        {
            var product = new HardDrive(InitialProductPrice);  // hardDrive.Weight == 1;

            for (int i = 0; i < Capacity; i++)
            {
                this.semi.LoadProduct(product);

            }

            Assert.AreEqual(true, this.semi.IsFull);
        }

        [Test]
        public void LoadProduct_ThrowInvalidOperationException_WhenTrunkIsFull()
        {
            var product = new HardDrive(InitialProductPrice);  // hardDrive.Weight == 1;

            for (int i = 0; i < 10; i++)
            {
                this.semi.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => this.semi.LoadProduct(product));
        }

        [Test]
        public void Unload_EmptyVehicle_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.semi.Unload());
        }

        [Test]
        public void Unload_LastAddedProduct()
        {
            var firstProduct = new HardDrive(InitialProductPrice);
            var secondProduct = new Ram(InitialProductPrice);
            var lastProduct = new SolidStateDrive(InitialProductPrice);

            semi.LoadProduct(firstProduct);
            semi.LoadProduct(secondProduct);
            semi.LoadProduct(lastProduct);

            var expectedUnloededProduct = semi.Unload();

            Assert.AreSame(expectedUnloededProduct, lastProduct);
        }
    }
}
