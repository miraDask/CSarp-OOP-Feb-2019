namespace NUnitTestProject1
{
    using ArrayDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MethodTests
    {
        [Test]
        public void AddElement_ToFullCapacityDatabase_ThrowsExeption()
        {
            var database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void AddElement_ToDatabase()
        {
            var database = new Database(1, 2, 3, 4, 5, 6, 7, 8);

            database.Add(9);

            var sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(sequence, database.FetchAllStoredData());
        }

        [Test]
        public void RemoveElement_FromEmptyDatabase_ThrowsExeption()
        {
            var database = new Database(1);
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_FromDatabase()
        {
            var database = new Database(1, 2, 3, 4, 5, 6, 7, 8);

            database.Remove();
            var sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(sequence, database.FetchAllStoredData());
        }

        [Test]
        public void FetchAllStoredData_Corectly()
        {
            var database = new Database(1, 2, 3, 4, 5, 6, 7, 8);

            var sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(sequence, database.FetchAllStoredData());
        }

        [Test]
        public void FetchAllStoredData_OfEmptyDatabase()
        {
            var database = new Database(1);
            database.Remove();
            var sequence = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(sequence, database.FetchAllStoredData());
        }
    }
}
