using Crayon.CloudSales.Core.Interfaces.Gateways;
using Crayon.CloudSales.Core.Interfaces.Repositories;
using Crayon.CloudSales.Core.Interfaces.Services;
using License = Crayon.CloudSales.Core.Entities.License;

namespace Crayon.CloudSales.Core.Services
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licenseRepository;
        private readonly ICloudComputingProviderGateway _cloudComputingProviderGateway;

        public LicenseService(ILicenseRepository licenseRepository, ICloudComputingProviderGateway cloudComputingProviderGateway)
        {
            _licenseRepository = licenseRepository;
            _cloudComputingProviderGateway = cloudComputingProviderGateway;
        }

        public async Task<IEnumerable<License>> GetLicensesForAccountAsync(string externalAccountId)
        {
            return await _licenseRepository.GetLicensesForAccountAsync(externalAccountId);
        }

        public async Task<License> CreateLicenseAsync(License license)
        {
            await _cloudComputingProviderGateway.OrderSoftwareProducts(license.ExternalSoftwareProductId, license.ExternalAccountId);
            var created = await _licenseRepository.CreateLicenseAsync(license);

            return created;
        }

        public async Task<License> UpdateLicenseAsync(License license)
        {
            return await _licenseRepository.UpdateLicenseAsync(license);
        }

        public async Task<bool> DeleteLicenseAsync(Guid licenseId)
        {
            return await _licenseRepository.DeleteLicenseAsync(licenseId);
        }
    }
}
