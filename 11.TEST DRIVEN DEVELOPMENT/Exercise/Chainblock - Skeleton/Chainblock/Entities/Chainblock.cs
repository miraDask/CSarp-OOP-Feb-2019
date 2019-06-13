namespace Chainblock.Entities
{
    using global::Chainblock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction transaction)
        {
            if (!this.Contains(transaction.Id))
            {
                this.transactions[transaction.Id] = transaction;
            }
        }

        public bool Contains(int id)
        {
            if (this.transactions.ContainsKey(id))
            {
                return true;
            }

            return false;
        }

        public bool Contains(ITransaction tx)
        {
            foreach (var kvp in this.transactions)
            {
                var transaction = kvp.Value;

                if (transaction == tx)
                {
                    return true;
                }
            }

            return false;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"Transaction with id: {id} does not exist");
            }

            var transaction = this.transactions[id];
            transaction.Status = newStatus;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with id: {id} does not exist");
            }

            return this.transactions[id];
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with id: {id} does not exist");
            }

            this.transactions.Remove(id);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(x => x.Value.Status == status))
            {
                throw new InvalidOperationException($"Transaction with status: {status.ToString()} does not exist.");
            }

            IEnumerable<ITransaction> transactionsWithEqualStatus = this.transactions.Where(x => x.Value.Status == status).Select(x => x.Value).ToList();
            return transactionsWithEqualStatus;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lowestValue, double hiestValue)
        {
            IEnumerable<ITransaction> transactionsInAmountRange 
                = this.transactions.Where(x => x.Value.Amount >= lowestValue && x.Value.Amount <= hiestValue)
                .Select(x => x.Value).ToList();
            return transactionsInAmountRange;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .OrderByDescending(x => x.Value.Amount)
                .ThenBy(x => x.Value.Id)
                .Select(x => x.Value)
                .ToArray();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(x => x.Value.Status == status))
            {
                throw new InvalidOperationException($"Transaction with status: {status.ToString()} does not exist.");
            }

            return this.transactions
                .OrderByDescending(x => x.Value.Amount)
                .Where(x => x.Value.Status == status)
                .Select(x => x.Value.From)
                .ToArray();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(x => x.Value.Status == status))
            {
                throw new InvalidOperationException($"Transaction with status: {status.ToString()} does not exist.");
            }

            return this.transactions
                .OrderByDescending(x => x.Value.Amount)
                .Where(x => x.Value.Status == status)
                .Select(x => x.Value.To)
                .ToArray();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (!this.transactions.Any(x => x.Value.To == receiver))
            {
                throw new InvalidOperationException($"Transaction with receiver: {receiver} does not exist.");
            }

            return this.transactions
               .OrderByDescending(x => x.Value.Amount)
               .ThenBy(x => x.Value.Id)
               .Where(x => x.Value.To == receiver)
               .Select(x => x.Value)
               .ToArray();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!this.transactions.Any(x => x.Value.From == sender))
            {
                throw new InvalidOperationException($"Transaction with sender: {sender} does not exist.");
            }

            return this.transactions
               .OrderByDescending(x => x.Value.Amount)
               .Where(x => x.Value.From == sender)
               .Select(x => x.Value)
               .ToArray();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!this.transactions.Any(x => x.Value.To == receiver)
                || !this.transactions.Any(x => x.Value.Amount >= lo && x.Value.Amount <= hi))
            {
                throw new InvalidOperationException($"There is no such transaction in collection.");
            }

            return this.transactions
               .OrderByDescending(x => x.Value.Amount)
               .ThenBy(x => x.Value.Id)
               .Where(x => x.Value.To == receiver)
               .Select(x => x.Value)
               .ToArray();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!this.transactions.Any(x => x.Value.From == sender)
                || !this.transactions.Any(x => x.Value.Amount > amount))
            {
                throw new InvalidOperationException($"There is no such transaction in collection.");
            }

            return this.transactions
               .OrderByDescending(x => x.Value.Amount)
               .Where(x => x.Value.From == sender && x.Value.Amount > amount)
               .Select(x => x.Value)
               .ToArray();
        }


        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions
              .OrderByDescending(x => x.Value.Amount)
              .Where(x => x.Value.Status == status && x.Value.Amount <= amount)
              .Select(x => x.Value)
              .ToArray();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
