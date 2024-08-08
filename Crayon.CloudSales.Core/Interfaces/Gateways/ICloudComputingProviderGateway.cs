using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Core.Interfaces.Gateways
{
    public interface ICloudComputingProviderGateway
    {
        Task<IEnumerable<SoftwareProduct>> ListSoftwareProducts();

        Task<OrderResponse> OrderSoftwareProducts(string externalSoftwareProductId, string accountId);
    }
}
