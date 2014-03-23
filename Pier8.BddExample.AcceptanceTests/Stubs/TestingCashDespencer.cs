namespace Pier8.BddExample.AcceptanceTests.Stubs
{
    using Interfaces;

    public class TestingCashDespencer : ICashDespencer
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
    }
}