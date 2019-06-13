namespace StorageMester.Tests.Structure.ProductsTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;

    [TestFixture]
    public class GpuTests
    {
        private const double InitialPrice = 2.5;
        private const double InitialWeight = 0.7;
        private Product gpu;

        [SetUp]
        public void SetUp()
        {
            this.gpu = new Gpu(InitialPrice);
        }

        [Test]
        public void Constructor_Creates_CorrectProduct()
        {
            Assert.IsNotNull(this.gpu);
            Assert.AreEqual(InitialPrice, this.gpu.Price);
            Assert.AreEqual(InitialWeight, this.gpu.Weight);
        }

        [Test]
        public void PriceProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialPrice, this.gpu.Price);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void PriceProperty_ThrowsInvalidOperationException_WhenSets_NegativeValue(double value)
        {
            Assert.Throws<InvalidOperationException>(() => this.gpu = new Gpu(value));
        }

        [Test]
        [TestCase(0)]
        [TestCase(double.MaxValue)]
        public void PriceProperty_Sets_CorrectValue(double value)
        {
            this.gpu = new Gpu(value);

            Assert.AreEqual(value, this.gpu.Price);
        }


        [Test]
        public void WeightProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialWeight, this.gpu.Weight);
        }
    }
}
