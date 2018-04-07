namespace NUnitTest.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            BankAccount account = new BankAccount(2000m);
            Assert.That(account.Amount.Equals(2000m));
        }

    }
}
