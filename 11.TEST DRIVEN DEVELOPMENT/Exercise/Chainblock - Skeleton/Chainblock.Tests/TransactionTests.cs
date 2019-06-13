namespace Chainblock.Tests
{
    using System;
    using NUnit.Framework;

    using Chainblock.Contracts;
    using Chainblock.Entities;

    [TestFixture]
    public class TransactionTests
    {
        private ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            this.transaction = new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 200);
        }

        [Test]
        public void Constructor_ShouldCreate_CorrectTransaction()
        {
            int id = 1;
            TransactionStatus status = TransactionStatus.Failed;
            string sender = "Pesho";
            string reciever = "Gosho";
            double amount = 200;

            Assert.AreEqual(id, this.transaction.Id);
            Assert.AreEqual(status, this.transaction.Status);
            Assert.AreEqual(sender, this.transaction.From);
            Assert.AreEqual(reciever, this.transaction.To);
            Assert.AreEqual(amount, this.transaction.Amount);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Id_Setter_ShouldThrow_ArgumentException_WhenInvalidValue_IsPassed(int invalidId)
        {
            TransactionStatus status = TransactionStatus.Failed;
            string sender = "Pesho";
            string reciever = "Gosho";
            double amount = 200;

            Assert.Throws<ArgumentException>(() 
                => this.transaction = new Transaction(invalidId, status ,sender, reciever, amount));

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void From_Setter_ShouldThrow_ArgumentException_WhenInvalidValue_IsPassed(string invalidSender)
        {
            int id = 1;
            TransactionStatus status = TransactionStatus.Failed;
            string reciever = "Gosho";
            double amount = 200;

            Assert.Throws<ArgumentException>(()
                => this.transaction = new Transaction(id, status, invalidSender, reciever, amount));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void To_Setter_ShouldThrow_ArgumentException_WhenInvalidValue_IsPassed(string invalidReciever)
        {
            int id = 1;
            TransactionStatus status = TransactionStatus.Failed;
            string sender = "Pesho";
            double amount = 200;

            Assert.Throws<ArgumentException>(()
                => this.transaction = new Transaction(id, status, sender, invalidReciever, amount));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Amount_Setter_ShouldThrow_ArgumentException_WhenInvalidValue_IsPassed(double InvalidAmount)
        {
            int id = 1;
            TransactionStatus status = TransactionStatus.Failed;
            string sender = "Pesho";
            string reciever = "Gosho";

            Assert.Throws<ArgumentException>(()
                => this.transaction = new Transaction(id, status, sender, reciever, InvalidAmount));
        }

        [Test]
        public void CompareTo_ShouldReturn_ZerroIfBothOfTransactionsHaveEqualId()
        {
            var secondTransaction = new Transaction(id: 1
                , status: TransactionStatus.Successfull
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            var expectedResult = 0;
            var result = this.transaction.CompareTo(secondTransaction);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
