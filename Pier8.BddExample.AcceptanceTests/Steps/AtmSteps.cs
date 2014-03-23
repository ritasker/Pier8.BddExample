namespace Pier8.BddExample.AcceptanceTests.Steps
{
    using FluentAssertions;
    using Stubs;
    using TechTalk.SpecFlow;

    [Binding]
    public class AtmSteps
    {
        private const decimal WithdrawalAmount = 64.00m;
        private const long AccountNumber = 178817326296;
        private const decimal InitialFunds = 256.00m;
        private const decimal AtmFunds = 1024.00m;
        private AutomatedTellerMachine _tellerMachine;
        private TestingAccountService _accountService;
        private TestingCashDispenser _cashDispenser;
        
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
            _accountService.AddAccount(AccountNumber, InitialFunds);
        }

        [Given(@"the dispenser contains cash")]
        public void GivenTheDispenserContainsCash()
        {
            _cashDispenser.AddFunds(AtmFunds);
        }

        [When(@"the customer requests cash")]
        public void WhenTheCustomerRequestsCash()
        {
            _tellerMachine.Withdraw(AccountNumber, WithdrawalAmount);
        }

        [Then(@"ensure the account is debited")]
        public void ThenEnsureTheAccountIsDebited()
        {
            var availablFunds = _accountService.GetAvailablFunds(AccountNumber);
            availablFunds.Should().Be((InitialFunds - WithdrawalAmount));

        }

        [Then(@"the cash is dispensed")]
        public void ThenTheCashIsDispensed()
        {
            var funds = _cashDispenser.GetFunds();
            funds.Should().Be((AtmFunds - WithdrawalAmount));
        }
    }
}