using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Core.Interfaces.Gateways;

namespace Crayon.CloudSales.Infrastructure.Gateways
{
    public class CloudComputingProviderGateway : ICloudComputingProviderGateway
    {
        private readonly IEnumerable<SoftwareProduct> _softwareProductsMock = new List<SoftwareProduct>
        {
            new() { ExternalId = "Office", Name = "Office", ExternalPrice = 123 },
            new() { ExternalId = "Excel", Name = "Excel", ExternalPrice = 321 },
        };

        public async Task<IEnumerable<SoftwareProduct>> ListSoftwareProducts()
        {
            return await Task.FromResult(_softwareProductsMock);
        }

        public async Task<OrderResponse> OrderSoftwareProducts(string externalSoftwareProductId, string accountId)
        {
            var orderResponseMock = new OrderResponse { ExternalAccountId = accountId, SoftwareProducts = _softwareProductsMock };
            return await Task.FromResult(orderResponseMock);
        }
    }
}
