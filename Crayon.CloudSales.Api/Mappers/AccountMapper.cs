using Crayon.CloudSales.Api.Dtos;
using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Infrastructure.Database.Mappers
{
    internal static class AccountMapper
    {
        internal static AccountDto ToAccountDto(Account account)
        {
            return new AccountDto
            {
                ExternalId = account.ExternalId,
                Name = account.Name,
                CustomerId = account.CustomerId,
                Licenses = account.Licenses.Select(LicenseMapper.ToLicenseDto).ToList()
            };
        }

        internal static Account ToAccount(AccountDto accountDto)
        {
            return new Account
            {
                ExternalId = accountDto.ExternalId,
                Name = accountDto.Name,
                CustomerId = accountDto.CustomerId,
                Licenses = accountDto.Licenses.Select(LicenseMapper.ToLicense).ToList()
            };
        }
    }
}
