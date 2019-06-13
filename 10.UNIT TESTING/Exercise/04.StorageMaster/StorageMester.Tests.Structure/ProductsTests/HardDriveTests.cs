namespace StorageMester.Tests.Structure.ProductsTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;

    [TestFixture]
    public class HardDriveTests
    {

        private const double InitialPrice = 3.5;
        private const double InitialWeight = 1;
        private Product hardDrive;

        [SetUp]
        public void SetUp()
        {
            this.hardDrive = new HardDrive(InitialPrice);
        }

        [Test]
        public void Constructor_Creates_CorrectProduct()
        {

            Assert.IsNotNull(this.hardDrive);
            Assert.AreEqual(InitialPrice, this.hardDrive.Price);
            Assert.AreEqual(InitialWeight, this.hardDrive.Weight);
        }

        [Test]
        public void PriceProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialPrice, this.hardDrive.Price);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(double.MinValue)]
        public void PriceProperty_ThrowsInvalidOperationException_WhenSets_NegativeValue(double value)
        {
            Assert.Throws<InvalidOperationException>(() => this.hardDrive = new HardDrive(value));
        }

        [Test]
        [TestCase(0)]
        [TestCase(double.MaxValue)]
        public void PriceProperty_Sets_CorrectValue(double value)
        {
            this.hardDrive = new HardDrive(value);

            Assert.AreEqual(value, this.hardDrive.Price);
        }


        [Test]
        public void WeightProperty_Gets_CorrectValue()
        {
            Assert.AreEqual(InitialWeight, this.hardDrive.Weight);
        }
    }
}
