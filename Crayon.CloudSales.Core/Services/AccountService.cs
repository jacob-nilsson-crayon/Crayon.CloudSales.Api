using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Core.Interfaces.Repositories;
using Crayon.CloudSales.Core.Interfaces.Services;

namespace Crayon.CloudSales.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAccounts(string customerId)
        {
            return await _accountRepository.GetAccountsAsync(customerId);
        }
    }
}
