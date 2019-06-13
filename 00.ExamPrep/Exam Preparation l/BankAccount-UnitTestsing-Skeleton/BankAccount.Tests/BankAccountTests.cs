using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount("MyAccount", 200);
        }

        [Test]
        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void NameSetter_ThrowsException_WhenInvalidNameLengthIsPassed(string name)
        {
            Assert.Throws<ArgumentException>(()
                => this.bankAccount = new BankAccount(name, 32));
        }

        [Test]
        public void NameGetet_ReturnsCorrectName()
        {
            Assert.AreEqual("MyAccount", this.bankAccount.Name);
        }

        [Test]
        public void BalanceSetter_ThrowsException_WhenInvalidValueIsPassed()
        {
            Assert.Throws<ArgumentException>(()
                => this.bankAccount = new BankAccount("Name", -1));
        }

        [Test]
        public void BalanseGetet_ReturnsCorrectValue()
        {
            Assert.AreEqual(200, this.bankAccount.Balance);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Deposit_ThrowsException_WhenInvalidValueIsPassed(decimal amount)
        {
            Assert.Throws<InvalidOperationException>(()
                => this.bankAccount.Deposit(amount));
        }

        [Test]
        public void Deposit_IncreaseBalance()
        {
             this.bankAccount.Deposit(32);

            Assert.AreEqual(232, this.bankAccount.Balance);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(300)]
        [TestCase(200)]
        public void Withdraw_ThrowsException_WhenInvalidValueIsPassed(decimal amount)
        {
            Assert.Throws<InvalidOperationException>(()
                => this.bankAccount.Withdraw(amount));
        }

        [Test]
        public void Withdraw_DecreaseBalance()
        {
            this.bankAccount.Withdraw(20);

            Assert.AreEqual(180, this.bankAccount.Balance);
        }
    }
}