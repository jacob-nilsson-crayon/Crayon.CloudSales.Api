using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Core.Interfaces.Services
{
    public interface ISoftwareProductService
    {
        Task<IEnumerable<SoftwareProduct>> ListSoftwareProducts();
    }
}