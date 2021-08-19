using System;

namespace Bank.Core
{
    public record Transaction(decimal Amount, DateTime Date, string Notes);
}