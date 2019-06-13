namespace StorageMester.Tests.Structure.ProductsTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;

    [TestFixture]
    public class RamTests
    {

        private const double InitialPrice = 22.5;
        private const double InitialWeight = 0.1;
        private Product ram;

        [SetUp]
        public void SetUp()
        {
            this.ram = new Ram(InitialPrice);
        }

        [Test]
        public void Constructor_Creates_CorrectProduct()
        {

            Assert.IsNotNull(this.ram);
            Assert.AreEqual(InitialPrice, this.ram.Price);
            Assert.AreEqual(InitialWeight, this.ram.Weight);
        }

        [Test]
        public void PriceProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialPrice, this.ram.Price);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void PriceProperty_ThrowsInvalidOperationException_WhenSets_NegativeValue(double value)
        {
            Assert.Throws<InvalidOperationException>(() => this.ram = new Ram(value));
        }

        [Test]
        [TestCase(0)]
        [TestCase(double.MaxValue)]
        public void PriceProperty_Sets_CorrectValue(double value)
        {
            this.ram = new Ram(value);

            Assert.AreEqual(value, this.ram.Price);
        }


        [Test]
        public void WeightProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialWeight, this.ram.Weight);
        }
    }
}
