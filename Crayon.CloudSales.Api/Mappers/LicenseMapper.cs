using Crayon.CloudSales.Api.Dtos;
using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Infrastructure.Database.Mappers
{
    internal static class LicenseMapper
    {
        internal static LicenseDto ToLicenseDto(License license)
        {
            return new LicenseDto
            {
                Id = license.Id,
                ExternalAccountId = license.ExternalAccountId,
                ExternalSoftwareProductId = license.ExternalSoftwareProductId,
                IsActive = license.IsActive,
                ValidTo = license.ValidTo,
            };
        }

        internal static License ToLicense(LicenseDto licenseDto)
        {
            return new License
            {
                Id = licenseDto.Id,
                ExternalAccountId = licenseDto.ExternalAccountId,
                ExternalSoftwareProductId = licenseDto.ExternalSoftwareProductId,
                IsActive = licenseDto.IsActive,
                ValidTo = licenseDto.ValidTo,
            };
        }
    }
}


