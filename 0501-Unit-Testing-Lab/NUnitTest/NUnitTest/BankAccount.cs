using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTest
{
    public class BankAccount
    {
        public BankAccount(decimal amount)
        {
            this.Amount += amount;
        }

        public decimal Amount { get; private set; }
    }
}
