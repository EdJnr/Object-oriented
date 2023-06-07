using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Bank
    {
        public string Number { get; } 
        public string Owner { get; set; }

        public decimal Balance { get 
            {
                decimal balance = 0;
                foreach (var item in Transactions)
                {
                    balance += item.Amount;
                }
                return balance;
            } 
        }

        private static int AccountSeed = 140;

        private List<transaction> Transactions = new List<transaction>();
       
        public Bank(string Owner,decimal balance)
        {
            this.Owner = Owner;
            this.Number = $"CAL{AccountSeed++}";

            //make initial deposit
            MakeDeposit(balance, DateTime.Now, $"Initial deposit for {Owner}");
        }

        public void MakeDeposit(decimal amount,DateTime date,string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to be deposited must be positive");
            }

            var withdrawal = new transaction(amount, date, note); 
            Transactions.Add(withdrawal);
        } 
        
        
        public void MakeWithdrawal(decimal amount,DateTime date,string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to be withdrawn must be not be less than zero");
            }
            if ((Balance - amount) < 0)
            {
                throw new InvalidOperationException("Not enough funds to perform this operation");
            }

            var withdrawal = new transaction(-amount, date, note);
            Transactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach (var item in Transactions)
            {
                report.AppendLine($"{item.Date}\t\t{item.Amount}\t\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
