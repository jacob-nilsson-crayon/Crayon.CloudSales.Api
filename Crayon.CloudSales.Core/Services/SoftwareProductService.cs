using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Core.Interfaces.Gateways;
using Crayon.CloudSales.Core.Interfaces.Services;

namespace Crayon.CloudSales.Core.Services
{
    public class SoftwareProductService : ISoftwareProductService
    {
        private readonly ICloudComputingProviderGateway _cloudComputingProviderGateway;

        public SoftwareProductService(ICloudComputingProviderGateway cloudComputingProviderGateway)
        {
            _cloudComputingProviderGateway = cloudComputingProviderGateway;
        }

        public async Task<IEnumerable<SoftwareProduct>> ListSoftwareProducts()
        {
            return await _cloudComputingProviderGateway.ListSoftwareProducts();
        }
    }
}
