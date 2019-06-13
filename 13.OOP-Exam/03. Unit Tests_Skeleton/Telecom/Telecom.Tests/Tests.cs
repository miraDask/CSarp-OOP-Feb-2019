namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void Setup()
        {
            this.phone = new Phone("2020", "S");

        }

        [Test]
        public void MakeSettsCorrectly()
        {
            Assert.AreEqual("2020", this.phone.Make);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakeThrowsEx(string make)
        {
            Assert.Throws<ArgumentException>(() => this.phone = new Phone(make, "S"));
        }

        [Test]
        public void ModelSettsCorrectly()
        {
            Assert.AreEqual("S", this.phone.Model);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelThrowsEx(string make)
        {
            Assert.Throws<ArgumentException>(() => this.phone = new Phone("2020", make));
        }

        [Test]
        public void AddContact()
        {
            this.phone.AddContact("Lili", "12345678");
            this.phone.AddContact("Mimi", "123456789");

            Assert.AreEqual(2, this.phone.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void AddContactThrowsEx(string make)
        {
            this.phone.AddContact("Lili", "12345678");
            this.phone.AddContact("Mimi", "123456789");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Lili", "12345678"));
        }


        [Test]
        public void CallThrowsEx()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Lili"));
        }


        [Test]
        public void CallReturns()
        {
            this.phone.AddContact("Lili", "12345678");
            string expResult = "Calling Lili - 12345678...";
            string result = this.phone.Call("Lili");
            Assert.AreEqual(expResult , result );
        }
    }
}