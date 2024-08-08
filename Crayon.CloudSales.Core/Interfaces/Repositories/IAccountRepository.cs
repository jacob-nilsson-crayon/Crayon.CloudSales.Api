using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync(string customerId);
    }
}
