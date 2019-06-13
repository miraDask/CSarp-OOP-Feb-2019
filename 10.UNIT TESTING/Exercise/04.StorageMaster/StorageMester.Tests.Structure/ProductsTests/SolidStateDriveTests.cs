namespace StorageMester.Tests.Structure.ProductsTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;

    [TestFixture]
    public class SolidStateDriveTests
    {

        private const double InitialPrice = 20.5;
        private const double InitialWeight = 0.2;
        private Product ssd;

        [SetUp]
        public void SetUp()
        {
            this.ssd = new SolidStateDrive(InitialPrice);
        }

        [Test]
        public void Constructor_Creates_CorrectProduct()
        {

            Assert.IsNotNull(this.ssd);
            Assert.AreEqual(InitialPrice, this.ssd.Price);
            Assert.AreEqual(InitialWeight, this.ssd.Weight);
        }

        [Test]
        public void PriceProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialPrice, this.ssd.Price);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void PriceProperty_ThrowsInvalidOperationException_WhenSets_NegativeValue(double value)
        {
            Assert.Throws<InvalidOperationException>(() => this.ssd = new SolidStateDrive(value));
        }

        [Test]
        [TestCase(0)]
        [TestCase(double.MaxValue)]
        public void PriceProperty_Sets_CorrectValue(double value)
        {
            this.ssd = new SolidStateDrive(value);

            Assert.AreEqual(value, this.ssd.Price);
        }


        [Test]
        public void WeightProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialWeight, this.ssd.Weight);
        }
    }
}
