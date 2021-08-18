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
            Console.WriteLine(
                $"Cuenta {bankAccount.Id} fue creada para {bankAccount.Owner} con ${bankAccount.Balance}");
            bankAccount.MakeWithdrawal(300, DateTime.Now, "Xbox One");
            Console.WriteLine(bankAccount.Balance);
            Console.WriteLine(bankAccount.GetAccountHistory());
        }
    }
}