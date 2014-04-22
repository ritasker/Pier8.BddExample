namespace Pier8.BddExample.AcceptanceTests.Steps
{
    using FluentAssertions;
    using Stubs;
    using TechTalk.SpecFlow;

    [Binding]
    public class AtmSteps
    {
        private const long AccountNumber = 178817326296;
        private const decimal InitialAccountFunds = 256.00m;
        private const decimal InitialAtmFunds = 1024.00m;
        private const decimal WithdrawalAmount = 64.00m;

        private AutomatedTellerMachine _tellerMachine;
        private TestingAccountService _accountService;
        private TestingCashDispenser _cashDispenser;
        private decimal _returnedFunds;

        [BeforeScenario]
        public void Setup()
        {
            _accountService = new TestingAccountService();
            _cashDispenser = new TestingCashDispenser();
            _tellerMachine = new AutomatedTellerMachine(_accountService, _cashDispenser);
        }

        [Given(@"the account is in credit")]
        public void GivenTheAccountIsInCredit()
        {
            _accountService.AddAccount(AccountNumber, InitialAccountFunds);
        }

        [Given(@"the dispenser contains cash")]
        public void GivenTheDispenserContainsCash()
        {
            _cashDispenser.AddFunds(InitialAtmFunds);
        }

        [When(@"the customer requests cash")]
        public void WhenTheCustomerRequestsCash()
        {
            _returnedFunds = _tellerMachine.Withdraw(WithdrawalAmount, AccountNumber);
        }

        [Then(@"ensure the account is debited")]
        public void ThenEnsureTheAccountIsDebited()
        {
            var availableFunds = _accountService.GetAvailableFunds(AccountNumber);
            availableFunds.Should().Be((InitialAccountFunds - WithdrawalAmount));

        }

        [Then(@"the cash is dispensed")]
        public void ThenTheCashIsDispensed()
        {
            _returnedFunds.Should().Be((WithdrawalAmount));
        }
    }
}