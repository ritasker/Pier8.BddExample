namespace Pier8.BddExample.Interfaces
{
    public interface IAccountService
    {
        void DebitAccount(long accountNumber, decimal debitAmount);
    }
}