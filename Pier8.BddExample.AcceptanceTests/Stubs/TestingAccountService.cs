namespace Pier8.BddExample.AcceptanceTests.Stubs
{
    using System.Collections.Generic;
    using Interfaces;

    public class TestingAccountService : IAccountService
    {
        private Dictionary<long, decimal> _accounts;

        public TestingAccountService()
        {
            _accounts = new Dictionary<long, decimal>();
        }

        public void AddAccount(long accountNumber, decimal funds)
        {
            _accounts.Add(accountNumber, funds);
        }

        public decimal GetAvailableFunds(long accountNumber)
        {
            return _accounts[accountNumber];
        }

        public void DebitAccount(long accountNumber, decimal debitAmount)
        {
            _accounts[accountNumber] -= debitAmount;
        }
    }
}