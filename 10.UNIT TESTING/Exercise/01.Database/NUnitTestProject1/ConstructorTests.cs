namespace Tests
{
    using ArrayDatabase;
    using NUnit.Framework;
    using System;

    public class ConstructorTests
    {

        [Test]
        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
        public void ThrowsExeption_WhenCreateObject_WithNoParameters_Ore_ParamsMoreThenCapacity(params int[] numbers)
        {
            
            Assert
                .Throws<InvalidOperationException>(() => new Database(numbers));
        }

        [Test]
        public void Creates_NewObject_Corectly()
        {
            var database = new Database(1,2,3);

            Assert.IsNotNull(database);
        }
    }
}