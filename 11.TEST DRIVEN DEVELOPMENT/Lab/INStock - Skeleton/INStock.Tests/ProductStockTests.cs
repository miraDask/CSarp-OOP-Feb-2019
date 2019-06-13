namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ProductStockTests
    {
        private IProductStock productStock;
        private IProduct product;

        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock();
            this.product = new Product(label: "SSD", price: 500m, quantity: 1);
        }

        [Test]
        public void Constructor_ShouldInitializeTheArray()
        {
            var expectedCapacity = 4;
            var actualCapacity = this.productStock.Capacity;
            var expectedCount = 0;
            var actualCount = this.productStock.Count;

            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void Add_ShouldIncreaseCount_WhenNewProductIsPassed()
        {

            this.productStock.Add(this.product);

            var expectedCount = 1;
            var resultCount = productStock.Count;

            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public void Add_ShouldIncrease_ProductsQuantity_WhenProductWithExistingLabel_IsPassed()
        {
            var secondProduct = new Product(label: "SSD", price: 500m, quantity: 1);
            this.productStock.Add(this.product);
            this.productStock.Add(secondProduct);

            var expectedQuantity = 1;
            var resultQuantity = this.product.Quantity;

            Assert.AreEqual(expectedQuantity, resultQuantity);
        }

        [Test]
        public void Add_ShouldResizeTheArray_WhenIsEqualToCount()
        {
            var productsCollection = GetCollection();

            this.AddCollectionOfProductsToProductsStock(productsCollection);

            var expectedCount = 8;
            var resultCount = this.productStock.Capacity;

            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public void Add_ShouldThrow_ArgumentNullException_WhenNullIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => this.productStock.Add(null));
        }

        [Test]
        public void IndexGetter_SholdReturn_CorrectValue()
        {
            this.productStock.Add(this.product);
            var product = this.productStock[0];

            Assert.AreEqual(this.product, product);

        }

        [Test]
        [TestCase(-1)]
        [TestCase(3)]
        public void IndexGetter_ShouldThrowIndexOutOfRangeException_WhenIsInvalid(int index)
        {
            var secondProduct = new Product(label: "HHD", price: 500m, quantity: 1);
            this.productStock.Add(this.product);
            this.productStock.Add(secondProduct);
            IProduct product;

            Assert.Throws<IndexOutOfRangeException>(() => product = this.productStock[index]);
        }

        [Test]
        public void IndexSetter_ShouldSet_CorrectValue()
        {
            this.productStock[0] = this.product;
            var actualProduct = this.productStock[0];
            Assert.AreSame(product, actualProduct);

        }

        [Test]
        [TestCase(-1)]
        [TestCase(2)]
        public void IndexSetter_ShouldThrowIndexOutOfRangeException_WhenIsInvalid(int index)
        {
            var secondProduct = new Product(label: "HDD", price: 500m, quantity: 1);
            this.productStock.Add(this.product);

            Assert.Throws<IndexOutOfRangeException>(() => this.productStock[index] = secondProduct);
        }

        [Test]
        public void Remove_ShouldThrowArgumentNullException_WhenNullIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => this.productStock.Remove(null));
        }

        [Test]
        public void Remove_ShouldReturnTrue_IfExitingProductIsPassed()
        {
            this.productStock.Add(this.product);
            var expectedResult = true;
            var result = this.productStock.Remove(this.product);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Remove_ShouldReturnFalse_IfNonExistingInArrayProductIsPassed()
        {
            var expectedResult = false;
            var result = this.productStock.Remove(this.product);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Remove_ShouldDecreaseCount_IfExitingProductIsPassed()
        {
            this.productStock.Add(this.product);
            var secondProduct = new Product(label: "HHD", price: 500m, quantity: 1);
            this.productStock.Add(secondProduct);
            this.productStock.Remove(this.product);
            var expectedResult = 1;
            var result = this.productStock.Count;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Remove_ShouldShiftLeftCorrectly()
        {
            var productsCollection = new[]
           {
                 new Product(label:"SSD1", price: 500m, quantity: 1),
                 new Product(label:"SSD2", price: 500m, quantity: 1),
                 new Product(label:"SSD3", price: 500m, quantity: 1),
            };

            for (int i = 0; i < productsCollection.Length; i++)
            {
                this.productStock.Add(productsCollection[i]);
            }

            var firstProduct = productsCollection[0];
            var secondProduct = productsCollection[1];

            this.productStock.Remove(firstProduct);

            var currentFirstProduct = this.productStock[0];

            Assert.AreEqual(currentFirstProduct, secondProduct);
        }

        [Test]
        public void Remove_ShouldShrinkTheArray_IfCapacityIsEqualToDoubleOfTheCount()
        {
            var productsCollection = new[]
            {
                 new Product(label:"SSD1", price: 500m, quantity: 1),
                 new Product(label:"SSD2", price: 500m, quantity: 1),
                 new Product(label:"SSD3", price: 500m, quantity: 1),
                 new Product(label:"SSD4", price: 500m, quantity: 1),
                 new Product(label:"SSD5", price: 500m, quantity: 1),
                 new Product(label:"SSD6", price: 500m, quantity: 1),
            };

            for (int i = 0; i < productsCollection.Length; i++)
            {
                this.productStock.Add(productsCollection[i]);
            }

            var firstProduct = productsCollection[0];
            var secondProduct = productsCollection[1];
            var lastProduct = productsCollection[5];

            this.productStock.Remove(firstProduct);
            this.productStock.Remove(secondProduct);
            this.productStock.Remove(lastProduct);

            var expectedCapacity = 4;
            var resultCapacity = this.productStock.Capacity;

            Assert.AreEqual(expectedCapacity, resultCapacity);
        }

        [Test]
        public void Contains_ShouldThrowArgumentNullException_WhenNullIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => this.productStock.Contains(null));
        }

        [Test]
        public void Contains_ShouldReturnTrue_IfExistingProductIsPassed()
        {
            this.productStock.Add(this.product);

            var expectedResult = true;
            var result = this.productStock.Contains(this.product);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Contains_ShouldReturnFalse_IfNonExistingProductIsPassed()
        {
            var expectedResult = false;
            var result = this.productStock.Contains(this.product);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(19)]
        public void Find_ShouldThrowIndexOutOfRangeException_WhenInvalidIndexIsPassed(int index)
        {
            this.productStock.Add(this.product);

            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(index));
        }

        [Test]
        public void Find_ShouldReturnCorrectValue()
        {
            this.productStock.Add(this.product);
            var secondProduct = new Product(label: "HHD", price: 500m, quantity: 1);
            this.productStock.Add(secondProduct);
            var expectedProduct = secondProduct;
            var returnedProduct = this.productStock.Find(1);

            Assert.AreSame(expectedProduct, returnedProduct);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FindByLabel_ShouldThrowArgumentException_IfInvalidLabelIsPassed(string invalidLabel)
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel(invalidLabel));
        }

        [Test]
        public void FindByLabel_ShouldThrowArgumentException_IfNoSuchProductIsInStock()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel("DDS"));
        }

        [Test]
        public void FindByLabel_ShouldReturn_CorrectProduct()
        {
            this.productStock.Add(this.product);
            var expectedProduct = this.product;
            var returnedProduct = this.productStock.FindByLabel("SSD");

            Assert.AreSame(expectedProduct, returnedProduct);
        }

        [Test]
        public void FindMostExpensiveProduct_ReturnsFirstMostExpensiveProduct()
        {
            this.productStock.Add(this.product);
            var secondProduct = new Product(label: "HHD", price: 500m, quantity: 1);
            this.productStock.Add(secondProduct);

            var expectedProduct = this.product;
            var returnedProduct = this.productStock.FindMostExpensiveProduct();

            Assert.AreSame(expectedProduct, returnedProduct);
        }

        [Test]
        public void FindMostExpensiveProduct_ShouldThrowInvalidOperationException_WhenCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.productStock.FindMostExpensiveProduct());
        }

        [Test]
        public void FindAllByPrice_ShouldThrowInvalidOperationException_IfInvalidPriceIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => this.productStock.FindAllByPrice(-2));
        }

        [Test]
        public void FindAllByPrice_ReturnsAllProductsInStock_WithGivenPrice()
        {
            var productsCollection = GetCollection();

            this.AddCollectionOfProductsToProductsStock(productsCollection);

            var resultCollection = this.productStock.FindAllByPrice(500);

            CollectionAssert.AreEqual(productsCollection, resultCollection);
        }

        [Test]
        public void FindAllByPrice_ReturnsEmptyCollection_IfNoneWereFound()
        {
            var resultCollection = this.productStock.FindAllByPrice(500);

            Assert.AreEqual(0, resultCollection.ToList().Count);
        }

        [Test]
        public void FindAllByQuantity_ShouldThrowInvalidOperationException_IfInvalidQuantityIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => this.productStock.FindAllByQuantity(-1));
        }

        [Test]
        public void FindAllByQuantity_ReturnsAllProductsInStock_WithGivenQuantity()
        {

            var productsCollection = GetCollection();

            this.AddCollectionOfProductsToProductsStock(productsCollection);

            var resultCollection = this.productStock.FindAllByQuantity(1);

            CollectionAssert.AreEqual(productsCollection, resultCollection);
        }

        [Test]
        public void FindAllByQuantity_ReturnsEmptyCollection_IfNoneWereFound()
        {
            var resultCollection = this.productStock.FindAllByQuantity(50);

            Assert.AreEqual(0, resultCollection.ToList().Count);
        }

        [Test]
        [TestCase(-1, 20)]
        [TestCase(-1, -2)]
        [TestCase( 2, -1)]
        public void FindAllInRange_ShouldThrowInvalidOperationException_IfInvalidValueIsPassed(double low, double hi)
        {
            Assert.Throws<InvalidOperationException>(() => this.productStock.FindAllInRange(low, hi));
        }

        [Test]
        public void FindAllInRange_ReturnsAllProductsInStock_WithGivenPrice()
        {
            var productsCollection = GetCollection();

            this.AddCollectionOfProductsToProductsStock(productsCollection);

            var expectedCollection = productsCollection.OrderByDescending(x => x.Price);
            var resultCollection = this.productStock.FindAllInRange(1, 10);

            CollectionAssert.AreEqual(expectedCollection, resultCollection);
        }

        [Test]
        public void FindAllInRange_ReturnsEmptyCollection_IfNoneWereFound()
        {
            var resultCollection = this.productStock.FindAllInRange(1, 3);

            Assert.AreEqual(0, resultCollection.ToList().Count);
        }

        [Test]
        public void GetEnumerator_Products_AreCorrect()
        {

            var productsCollection = GetCollection();

            this.AddCollectionOfProductsToProductsStock(productsCollection);

            var expectedCollection = productsCollection.Take(3).ToArray();
            var resultCollection = this.productStock.Take(3).ToArray();

            CollectionAssert.AreEqual(expectedCollection , resultCollection);
        }

        private IProduct[] GetCollection()
        {
            return new[]
           {
                 new Product(label:"SSD1", price: 5, quantity: 1),
                 new Product(label:"SSD2", price: 6, quantity: 1),
                 new Product(label:"SSD3", price: 7, quantity: 1),
                 new Product(label:"SSD4", price: 8, quantity: 1),
                 new Product(label:"SSD5", price: 9, quantity: 1),
                 new Product(label:"SSD6", price: 10, quantity: 1),
            };
        }

        private void AddCollectionOfProductsToProductsStock(IProduct[] productsCollection)
        {
            foreach (var product in productsCollection)
            {
                this.productStock.Add(product);
            }
        }
    }
}
