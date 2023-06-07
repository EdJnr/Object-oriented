using System.ComponentModel;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Bank("Edward Nii Amarh Amartey Junior", 100);
            Console.WriteLine($"New account created for {account1.Owner} with amount of {account1.Balance} and account number {account1.Number}");

            account1.MakeDeposit(1000, DateTime.Now, "Deposit at Teshie Branch");
            account1.MakeWithdrawal(100, DateTime.Now, "Withdrawal at Teshie Branch");
            Console.WriteLine($"Current balance is {account1.Balance} cedis");
            Console.WriteLine(account1.GetAccountHistory());


        }
    }
}