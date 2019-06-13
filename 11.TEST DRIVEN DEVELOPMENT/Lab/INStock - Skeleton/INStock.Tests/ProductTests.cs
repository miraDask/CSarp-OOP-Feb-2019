namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        private Product product;
        [Test]
        public void Constructor_ShouldInitializeCorrectProduct()
        {
            product = new Product("Meat", 3.40m, 2);
            Assert.AreEqual("Meat", product.Label);
            Assert.AreEqual(3.40, product.Price);
            Assert.AreEqual(2, product.Quantity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Constructor_ShouldThrowArgumentException_WhenInvalidLabelIsPassed(string invalidLabel)
        {
            Assert.Throws<ArgumentException>(() => product = new Product(invalidLabel, 3.40m, 2));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Constructor_ShouldThrowArgumentException_WhenInvalidPriceIsPassed(decimal invalidPrice)
        {
            Assert.Throws<ArgumentException>(() => product = new Product("Meat", invalidPrice, 2));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void Constructor_ShouldThrowArgumentException_WhenInvalidQuantityIsPassed(int invalidQuantity)
        {
            Assert.Throws<ArgumentException>(() => product = new Product("Meat", 3.40m , invalidQuantity));
        }


        [Test]
        public void CompareTo_ShouldReturnLabelWhitGreaterAsciiCode()
        {
            var firstProductLabel = "abc";
            var secondProductLabel = "ab";

            var firstProduct = new Product(firstProductLabel, 3.40m, 2);
            var secondProduct = new Product(secondProductLabel, 3.40m, 2);

            var expectedResult = 1;
            var result = firstProduct.CompareTo(secondProduct);

            Assert.AreEqual(expectedResult, result);
        }
    }
} 