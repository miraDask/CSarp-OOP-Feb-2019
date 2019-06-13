namespace PersonData.Tests
{
    using NUnit.Framework;
    using PeopleDatabasa;
    using System;

    [TestFixture]
    public class MethodsTests
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
        public void Get_CollectionLength_Corectly()
        {
            Assert.AreEqual(0, database.CollectionLength);
        }

        [Test]
        public void AddingPerson_Corectly()
        {
            this.database.Add(this.person);

            Assert.AreEqual(1, this.database.CollectionLength);
        }

        [Test]
        public void AddingPerson_WithExistingUsername_ThrowsExeption()
        {
            this.database.Add(this.person);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(this.person));
        }

        [Test]
        public void AddingPerson_WithExistingId_ThrowsExeption()
        {
            this.database.Add(this.person);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(this.person));
        }

        [Test]
        public void RemovingPerson_FromEmptyCollection()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void RemovingPerson_FromCollection_Corectly()
        {
            this.database.Add(this.person);
            this.database.Remove();

            Assert.AreEqual(0, this.database.CollectionLength);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FindByUsername_TrowsExeption_WhenInvalidParameter_IsPassed(string element)
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(element));
        }

        [Test]
        public void FindByUsername_TrowsExeption_WhenTargetingNonExistingPerson()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Sosho"));
        }

        [Test]
        public void FindByUsername_Returns_CorrectPerson()
        {
            this.database.Add(this.person);
            var targetPerson = this.database.FindByUsername("Miho");

            Assert.IsNotNull(targetPerson);
        }

        [Test]
        public void FindById_TrowsExeption_WhenNegativParameter_IsPassed()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void FindById_TrowsExeption_WhenTargetingNonExistingPerson()
        {
            this.database.Add(this.person);
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(1234));
        }

        [Test]
        public void FindById_Returns_CorrectPerson()
        {
            this.database.Add(this.person);
            var targetPerson = this.database.FindById(123);

            Assert.IsNotNull(targetPerson);
        }

        [Test]
        public void FetchAllStoredData_ReturnsCorectValue()
        {
            this.database.Add(this.person);
            var personCollection = this.database.FetchAllStoredData();

            Assert.AreEqual(1, personCollection.Length);
        }
    }
}

