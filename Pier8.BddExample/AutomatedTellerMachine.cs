namespace Pier8.BddExample
{
    using Interfaces;

    public class AutomatedTellerMachine
    {
        private readonly IAccountService _accountService;
        private readonly ICashDespencer _cashDespencer;

        public AutomatedTellerMachine(IAccountService accountService, ICashDespencer cashDespencer)
        {
            _accountService = accountService;
            _cashDespencer = cashDespencer;
        }

        public void Withdraw(decimal withdrawalAmount)
        {
            throw new System.NotImplementedException();
        }
    }
}
