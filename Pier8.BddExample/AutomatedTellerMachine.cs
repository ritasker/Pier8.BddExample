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

        public decimal Withdraw(long accountNumber, decimal withdrawalAmount)
        {
            _accountService.DebitAccount(accountNumber, withdrawalAmount);
            var dispensedCash = _cashDispenser.Dispense(withdrawalAmount);
            return dispensedCash;
        }
    }
}
