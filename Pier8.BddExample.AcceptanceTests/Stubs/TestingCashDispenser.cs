namespace Pier8.BddExample.AcceptanceTests.Stubs
{
    using Interfaces;

    public class TestingCashDispenser : ICashDispenser
    {
        private decimal _funds;

        public void AddFunds(decimal funds)
        {
            _funds = funds;
        }

        public decimal GetFunds()
        {
            return _funds;
        }

        public decimal Dispense(decimal amount)
        {
            _funds -= amount;
            return amount;
        }
    }
}