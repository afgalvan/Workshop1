using System;
using System.Globalization;
using System.Threading;
using Bank.Core;

namespace Bank
{
    class Program
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            var bankAccount = new BankAccount("Rosa", 1000);
            bankAccount.MakeWithdrawal(300, "Xbox One");
            Console.WriteLine(bankAccount.Balance);
            Console.WriteLine(bankAccount.GetAccountHistory());
            Console.ReadKey();
        }
    }
}