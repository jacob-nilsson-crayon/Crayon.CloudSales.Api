using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Infrastructure.Database.Entities;

namespace Crayon.CloudSales.Infrastructure.Database.Mappers
{
    internal static class AccountDbMapper
    {
        internal static AccountEntity ToAccountDbEntity(Account account)
        {
            return new AccountEntity
            {
                ExternalId = account.ExternalId,
                Name = account.Name,
                CustomerId = account.CustomerId,
                Licenses = account.Licenses.Select(LicenseDbMapper.ToLicenseDbEntity).ToList()
            };
        }

        internal static Account ToAccount(AccountEntity accountEntity)
        {
            return new Account
            {
                ExternalId = accountEntity.ExternalId,
                Name = accountEntity.Name,
                CustomerId = accountEntity.CustomerId,
                Licenses = accountEntity.Licenses.Select(LicenseDbMapper.ToLicense).ToList()
            };
        }
    }
}
