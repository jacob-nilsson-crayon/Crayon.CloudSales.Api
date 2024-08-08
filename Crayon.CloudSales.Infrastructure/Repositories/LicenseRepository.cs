using AutoMapper;
using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Core.Interfaces.Repositories;
using Crayon.CloudSales.Infrastructure.Database.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Crayon.CloudSales.Infrastructure.Repositories
{
    internal class LicenseRepository : ILicenseRepository
    {
        private readonly CrayonCloudSalesDbContext _context;

        public LicenseRepository(CrayonCloudSalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<License>> GetLicensesForAccountAsync(string externalAccountId)
        {
            var licenseDbEntities = await _context.Licenses
                .Where(l => l.ExternalAccountId == externalAccountId)
                .ToListAsync();

            return licenseDbEntities.Select(l => LicenseDbMapper.ToLicense(l));
        }

        public async Task<License> CreateLicenseAsync(License license)
        {
            var dbEntityToSave = LicenseDbMapper.ToLicenseDbEntity(license);
            var entry = await _context.Licenses.AddAsync(dbEntityToSave);
            var addedLicense = LicenseDbMapper.ToLicense(entry.Entity);

            await _context.SaveChangesAsync();

            return addedLicense;
        }

        public async Task<License> UpdateLicenseAsync(License license)
        {
            var dbEntityToSave = LicenseDbMapper.ToLicenseDbEntity(license);
            var existingDbEntity = await _context.Licenses.FirstOrDefaultAsync(l => l.Id == license.Id);

            if (existingDbEntity == null)
            {
                throw new KeyNotFoundException("Could not find license to update.");
            }

            _context.Entry(existingDbEntity).CurrentValues.SetValues(dbEntityToSave);
            var updatedLicense = LicenseDbMapper.ToLicense(existingDbEntity);

            await _context.SaveChangesAsync();

            return updatedLicense;
        }

        public async Task<bool> DeleteLicenseAsync(Guid licenseId)
        {
            var dbEntity = await _context.Licenses.FirstOrDefaultAsync(l => l.Id == licenseId);

            if(dbEntity == null)
            {
                throw new KeyNotFoundException("Could not find license to delete.");
            }

            _context.Licenses.Remove(dbEntity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
