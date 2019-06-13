using System;

namespace BankAccount
{
    public class BankAccount
    {
        private string name;
        private decimal balance;

        public BankAccount(string name, decimal amount)
        {
            this.Name = name;
            this.Balance = amount;
        }
        // NameSetter_ThrowsException_WhenInvalidNameLengthIsPassed() - 2, 26
        // NameGetet_ReturnsCorrectName()
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 3 || value.Length > 25)
                {
                    throw new ArgumentException($"Invalid {nameof(this.name)} length");
                }

                this.name = value;
            }
        }
        // BalanceSetter_ThrowsException_WhenInvalidValueIsPassed() - -1
        // BalanseGetet_ReturnsCorrectValue()
        public decimal Balance
        {
            get => this.balance;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Balance)} must be positive!");
                }

                this.balance = value;
            }
        }
        // DepositSetter_ThrowsException_WhenInvalidValueIsPassed() - -1,0
        // DepositGetet_ReturnsCorrectValue()
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException($"{nameof(amount)} must be positive");
            }

            this.Balance += amount;
        }

        // Withdraw_ThrowsException_WhenInvalidAmountIsPassed() - -1 , <= amount
        // Withdraw_DecreaseBalanceCorrectly()
        public decimal Withdraw(decimal amount)
        {
            if (this.Balance <= amount || amount < 0)
            {
                throw new InvalidOperationException($"{nameof(amount)} must be more than 0 and less than your balance");
            }

            this.Balance -= amount;
            return amount;
        }
    }
}
