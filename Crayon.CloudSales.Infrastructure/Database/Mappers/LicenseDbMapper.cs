using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Infrastructure.Database.Entities;

namespace Crayon.CloudSales.Infrastructure.Database.Mappers
{
    internal static class LicenseDbMapper
    {
        internal static LicenseEntity ToLicenseDbEntity(License license)
        {
            return new LicenseEntity
            {
                Id = license.Id,
                ExternalAccountId = license.ExternalAccountId,
                ExternalSoftwareProductId = license.ExternalSoftwareProductId,
                IsActive = license.IsActive,
                ValidTo = license.ValidTo,
            };
        }

        internal static License ToLicense(LicenseEntity licenseEntity)
        {
            return new License
            {
                Id = licenseEntity.Id,
                ExternalAccountId = licenseEntity.ExternalAccountId,
                ExternalSoftwareProductId = licenseEntity.ExternalSoftwareProductId,
                IsActive = licenseEntity.IsActive,
                ValidTo = licenseEntity.ValidTo,
            };
        }
    }
}
