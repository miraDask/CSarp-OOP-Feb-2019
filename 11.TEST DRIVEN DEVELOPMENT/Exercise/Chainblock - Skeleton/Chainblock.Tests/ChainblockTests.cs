namespace Chainblock.Tests
{
    using Chainblock.Contracts;
    using Chainblock.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.transaction = new Transaction(
                 id: 1
                ,status: TransactionStatus.Failed
                ,sender: "Pesho"
                ,reciever: "Gosho"
                ,amount: 200);
        }

        [Test]
        public void Constructor_Creates_NotNullCollectionWithZerroCount()
        {
            Assert.IsNotNull(this.chainblock);
            Assert.AreEqual(0, this.chainblock.Count);
        }

        [Test]
        public void Add_IncreasesCount_IfNonPresentInCollectionTransactionIsPassed()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(id: 2
                , status: TransactionStatus.Successfull
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(secondTransaction);
            var expectedCount = 2;
            var resultCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, resultCount);

        }

        [Test]
        public void ContainsId_ReturnsTrue_IfExistingIncollectionIdIsPassed()
        {
            this.chainblock.Add(this.transaction);
            var expectedResult = true;
            var actualResult = this.chainblock.Contains(1);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void ContainsId_ReturnsFalse_IfNonExistingIncollectionId_IsPassed()
        {
            this.chainblock.Add(this.transaction);
            var expectedResult = false;
            var actualResult = this.chainblock.Contains(2);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_ShouldNotIncreaseCount_WhenTransactionWithExistingInCollectionIdIsPassed()
        {
            var secondTransaction = new Transaction(
                id: 1
                , status: TransactionStatus.Successfull
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(this.transaction);
            this.chainblock.Add(secondTransaction);

            var expectedCount = 1;
            var resultCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public void ContainsTransaction_ReturnsTrue_IfExistingIncollectionTransactionIsPassed()
        {
            this.chainblock.Add(this.transaction);
            var expectedResult = true;
            var actualResult = this.chainblock.Contains(this.transaction);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_IfNonExistingIncollectionTransactionIsPassed()
        {
            var expectedResult = false;
            var actualResult = this.chainblock.Contains(this.transaction);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsArgumentException_IfTransactionDoNotExistsInCollection()
        {
            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(id: 1, newStatus: TransactionStatus.Successfull));
        }

        [Test]
        public void ChangeTransactionStatus_ChangesStatus_IfInCollectionExistsTransactionWithPassedId()
        {
            this.chainblock.Add(this.transaction);
            this.chainblock.ChangeTransactionStatus(id: 1, newStatus: TransactionStatus.Successfull);

            var expectedStatus = TransactionStatus.Successfull;
            var actualStatus = this.transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void GetById_ThrowsInvalidOperationException_WhenNonExistingInCollectionIdIsPassed()
        {
            Assert.Throws<InvalidOperationException>(()
                => this.chainblock.GetById(id: 1));
        }

        [Test]
        public void GetById_ReturnsCorrectTransaction_WhenExistingInCollectionIdIsPassed()
        {
            this.chainblock.Add(this.transaction);

            var expectedTransaction = this.transaction;
            var actialTransaction = this.chainblock.GetById(id: 1);

            Assert.AreSame(expectedTransaction, actialTransaction);
        }

        [Test]
        public void RemoveTransactionById_ThrowsInvalidOperationException_WhenNonExistingInCollectionIdIsPassed()
        {
            Assert.Throws<InvalidOperationException>(()
                => this.chainblock.RemoveTransactionById(id: 1));
        }

        [Test]
        public void RemoveTransactionById_DecreasesCount_WhenExistingInCollectionIdIsPassed()
        {
            this.chainblock.Add(this.transaction);
            this.chainblock.RemoveTransactionById(id: 1);
            var expectedResult = 0;
            var actualResult = this.chainblock.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatus_ThrowsInvalidOperationException_WhenThereIsNotSuchTransactionWithPassedStatusInCollection()
        {
            IEnumerable<ITransaction> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsCorrectCollection_WhenExistingInCollectionStatusIsPassed()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(secondTransaction);

            var lastTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 10);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                this.transaction,
                secondTransaction,
                lastTransaction
            };

            var returnedTransactions = this.chainblock.GetByTransactionStatus(TransactionStatus.Failed);

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetAllInAmountRange_ReturnsEmptyCollection_WhenThereIsNoTransactionsWhithAmountThatIsInThePassedRange()
        {
            var allInAmountRange = this.chainblock.GetAllInAmountRange(lo: 1, hi: 10);
            var expectedCount = 0;
            var actualCount = allInAmountRange.ToArray().Length;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void GetAllInAmountRange_ReturnsCorrectCollection_WhenThereAreTransactionsWhithAmountThatIsInThePassedRange()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(secondTransaction);

            var lastTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 10);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                this.transaction,
                secondTransaction,
                lastTransaction
            };

            var returnedTransactions = this.chainblock.GetAllInAmountRange(1 , 200);

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 200);

            this.chainblock.Add(secondTransaction);

            var lastTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 10);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                this.transaction,
                secondTransaction,
                lastTransaction
            };

            var returnedTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionWithPassedStatusInCollection()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<string> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(secondTransaction);

            var lastTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 10);

            this.chainblock.Add(lastTransaction);

            IEnumerable<string> transactions = new List<string>()
            {
                "Pesho",
                "Mimi",
                "Mimi"
            };

            var returnedTransactions = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionWithPassedStatusInCollection()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<string> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(secondTransaction);

            var lastTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 10);

            this.chainblock.Add(lastTransaction);

            IEnumerable<string> transactions = new List<string>()
            {
                "Gosho",
                "Lili",
                "Lili"
            };

            var returnedTransactions = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionWithPassedRecieverInCollection()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<ITransaction> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetByReceiverOrderedByAmountThenById("Me"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(secondTransaction);

            var thirdTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 100);

            this.chainblock.Add(thirdTransaction);

            var lastTransaction = new Transaction(
                id: 4
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 100);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                thirdTransaction,
                lastTransaction,
                secondTransaction
            };

            var returnedTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById("Lili");

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionInCollectionWithPassedSender()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<ITransaction> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetBySenderOrderedByAmountDescending("Me"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 20);

            this.chainblock.Add(secondTransaction);

            var thirdTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 400);

            this.chainblock.Add(thirdTransaction);

            var lastTransaction = new Transaction(
                id: 4
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 100);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                thirdTransaction,
                lastTransaction,
                secondTransaction
            };

            var returnedTransactions = this.chainblock.GetBySenderOrderedByAmountDescending("Mimi");

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionInCollectionWithPassedSender()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<ITransaction> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetByReceiverAndAmountRange("Me", 1 , 2));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionInCollectionInPassedRange()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<ITransaction> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetByReceiverAndAmountRange("Gosho", 1 , 15));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 100);

            this.chainblock.Add(secondTransaction);

            var thirdTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 400);

            this.chainblock.Add(thirdTransaction);

            var lastTransaction = new Transaction(
                id: 4
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 100);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                thirdTransaction,
                secondTransaction,
                lastTransaction
            };

            var returnedTransactions = this.chainblock.GetByReceiverAndAmountRange("Lili", 50, 400);

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionInCollectionWithPassedSender()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<ITransaction> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetBySenderAndMinimumAmountDescending("Me", 1));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsInvalidOperationException_WhenThereIsNoSuchTransactionInCollectionWithAmountBigerThenPassedAmount()
        {
            this.chainblock.Add(this.transaction);

            IEnumerable<ITransaction> transactionsWhitEqualStatus = null;

            Assert.Throws<InvalidOperationException>(()
                => transactionsWhitEqualStatus = this.chainblock.GetBySenderAndMinimumAmountDescending("Gosho", 1000));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);

            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 200);

            this.chainblock.Add(secondTransaction);

            var thirdTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 400);

            this.chainblock.Add(thirdTransaction);

            var lastTransaction = new Transaction(
                id: 4
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 100);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                thirdTransaction,
                secondTransaction,
            };

            var returnedTransactions = this.chainblock.GetBySenderAndMinimumAmountDescending("Mimi", 100);

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenThereIsNoTransactianWithPassedStatusOrPassedMaximumAmount()
        {
            this.chainblock.Add(this.transaction);

            var amountCheckCollection =
                this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 150);

            var statusCheckCollection =
                this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 200);

            var expectedCount = 0;
            var actualAmountCheckCollectionCount = amountCheckCollection.ToArray().Length;
            var actualStatusCheckCollectionCount = statusCheckCollection.ToArray().Length;

            Assert.AreEqual(expectedCount, actualAmountCheckCollectionCount);
            Assert.AreEqual(expectedCount, actualStatusCheckCollectionCount);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsCorrectCollection()
        {
            this.chainblock.Add(this.transaction);
            var secondTransaction = new Transaction(
                id: 2
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 100);

            this.chainblock.Add(secondTransaction);

            var lastTransaction = new Transaction(
                id: 3
                , status: TransactionStatus.Failed
                , sender: "Mimi"
                , reciever: "Lili"
                , amount: 1000);

            this.chainblock.Add(lastTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                this.transaction,
                secondTransaction
            };

            var returnedTransactions =
                this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 200);

            CollectionAssert.AreEqual(transactions, returnedTransactions);
        }
    }
}
