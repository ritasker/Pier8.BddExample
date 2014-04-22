namespace Pier8.BddExample.UnitTests
{
    using FluentAssertions;
    using Interfaces;
    using Moq;
    using Xunit;

    public class WhenAskedToWithdrawCash
    {
        private readonly Mock<IAccountService> _accountService;
        private readonly Mock<ICashDispenser> _cashDespencer;
        private readonly decimal _result;
        private readonly decimal _withdrawalAmount;

        public WhenAskedToWithdrawCash()
        {
            const long accountNumber = 178817326296;
            _withdrawalAmount = 64.00m;

            _accountService = new Mock<IAccountService>();
            _accountService
                .Setup(x => x.DebitAccount(accountNumber, _withdrawalAmount))
                .Verifiable();

            _cashDespencer = new Mock<ICashDispenser>();
            _cashDespencer
                .Setup(x => x.GetCash(_withdrawalAmount))
                .Returns(_withdrawalAmount)
                .Verifiable();

            var subject = new AutomatedTellerMachine(_accountService.Object, _cashDespencer.Object);

            _result = subject.Withdraw(_withdrawalAmount, accountNumber);
        }

        [Fact]
        public void ShouldDebitRequestedAmountFromAccount()
        {
            _accountService.Verify();
        }

        [Fact]
        public void ShouldGetTheCashFromTheDispenser()
        {
            _cashDespencer.Verify();
        }

        [Fact]
        public void ShouldDispenceTheCash()
        {
            _result.Should().Be(_withdrawalAmount);
        }
    }
}
