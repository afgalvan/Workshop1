using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humanizer;

namespace Bank.Core
{
    public class BankAccount
    {
        public string  Id      { get; }
        public string  Owner   { get; }
        public decimal Balance => _transactionHistory.Sum(transaction => transaction.Amount);

        private readonly List<Transaction> _transactionHistory = new();
        private static   int               _accountNumberSeed  = 1;

        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            MakeDeposit(initialBalance, "Initial Balance");
            Id = (_accountNumberSeed++).ToString();
        }

        public void MakeDeposit(decimal amount, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Cantidad a depositar debe ser mayor a 0.");
            }

            var deposit = new Transaction(amount, DateTime.Now, note);
            _transactionHistory.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Cantidad a depositar debe ser mayor a 0.");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("No hay suficientes fondos para este retiro.");
            }

            var withdrawal = new Transaction(-amount, DateTime.Now, note);
            _transactionHistory.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            static string AmountInWords(Transaction transaction) =>
                ((int) transaction.Amount).ToWords();

            var report = new StringBuilder();
            report.AppendLine("Fecha\t\t\tCantidad\t\tDescripción");
            _transactionHistory.ForEach(transaction =>
                report.AppendLine($"{transaction.Date}\t{AmountInWords(transaction)}\t\t{transaction.Notes}"));
            return report.ToString();
        }
    }
}