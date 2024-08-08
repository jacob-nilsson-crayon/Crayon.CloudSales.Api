using Crayon.CloudSales.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.CloudSales.Infrastructure.Database
{
    public static class CrayonCloudSalsesDbInitializer
    {
        public static void Initialize(CrayonCloudSalesDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Accounts.Any() && !context.Licenses.Any())
            {
                var customerId = "KnowCustomerId";
                var accountId = "knownAccountId@knownCustomer.com";

                var account = new AccountEntity
                {
                    CustomerId = customerId,
                    ExternalId = accountId,
                    Name = "user1"
                };

                var license = new LicenseEntity
                {
                    Id = Guid.NewGuid(),
                    ExternalAccountId = accountId,
                    ExternalSoftwareProductId = "OfficeId",
                    IsActive = true,
                    ValidTo = DateTime.UtcNow.AddYears(1)
                };

                context.Accounts.Add(account);
                context.Licenses.Add(license);

                context.SaveChanges();
            }
        }
    }
}
