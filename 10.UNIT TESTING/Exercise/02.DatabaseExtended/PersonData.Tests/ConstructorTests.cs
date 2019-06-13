namespace Tests
{
    using NUnit.Framework;
    using PeopleDatabasa;

    [TestFixture]
    public class ConstructorTests
    {
        private Database database;
        private IPerson person;

        [SetUp]
        public void Setup()
        {
            this.database = new Database();
            this.person = new Person("Miho", 123);
        }

        [Test]
        public void CreatesNewDatabase_Corectly()
        {
            Assert.AreEqual(0, database.CollectionLength);
            Assert.IsNotNull(this.database);
        }

    }  
}