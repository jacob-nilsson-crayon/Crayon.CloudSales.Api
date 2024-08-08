using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Core.Interfaces.Repositories
{
    public interface ILicenseRepository
    {
        Task<IEnumerable<License>> GetLicensesForAccountAsync(string externalAccountId);

        Task<License> CreateLicenseAsync(License license);

        Task<License> UpdateLicenseAsync(License license);

        Task<bool> DeleteLicenseAsync(Guid licenseId);
    }
}
