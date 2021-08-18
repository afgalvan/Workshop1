using System;
using Bank.Core;
using Xunit;

namespace CSharp.Test
{
    public class BankAccountTest
    {
        private readonly BankAccount _account;

        public BankAccountTest()
        {
            _account = new BankAccount("Kendra", 1000);
        }

        [Fact]
        public void ShouldThrowException_WhenDoingNegativeDeposit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _account.MakeDeposit(
                    -200,
                    DateTime.Now,
                    "Attempt to do an invalid deposit")
            );
        }

        [Fact]
        public void ShouldThrowException_WhenCreatingAnInvalidAccount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new BankAccount("Invalid", -2000)
            );
        }

        [Fact]
        public void ShouldThrowException_WhenTryingToOverdraw()
        {
            Assert.Throws<InvalidOperationException>(() =>
                _account.MakeWithdrawal(500000, DateTime.Now, "Attempt to overdraw")
            );
        }
    }
}