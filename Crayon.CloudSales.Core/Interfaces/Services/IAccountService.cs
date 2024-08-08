using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts(string customerId);
    }
}