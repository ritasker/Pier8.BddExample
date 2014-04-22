namespace Pier8.BddExample
{
    using Interfaces;

    public class AutomatedTellerMachine
    {
        private readonly IAccountService _accountService;
        private readonly ICashDispenser _cashDispenser;

        public AutomatedTellerMachine(IAccountService accountService, ICashDispenser cashDispenser)
        {
            _accountService = accountService;
            _cashDispenser = cashDispenser;
        }

        public decimal Withdraw(decimal withdrawalAmount, long accountNumber)
        {
            _accountService.DebitAccount(accountNumber, withdrawalAmount);
            var dispensedCash = _cashDispenser.GetCash(withdrawalAmount);
            return dispensedCash;
            //return 0.0m;
        }
    }
}
