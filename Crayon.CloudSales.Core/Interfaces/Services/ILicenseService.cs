using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Core.Interfaces.Services
{
    public interface ILicenseService
    {
        Task<License> CreateLicenseAsync(License license);

        Task<License> UpdateLicenseAsync(License license);

        Task<IEnumerable<License>> GetLicensesForAccountAsync(string externalAccountId);

        Task<bool> DeleteLicenseAsync(Guid licenseId);
    }
}