using Crayon.CloudSales.Api.Dtos;
using Crayon.CloudSales.Core.Interfaces.Services;
using Crayon.CloudSales.Infrastructure.Database.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.CloudSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : Controller
    {
        private readonly ILicenseService _service;

        public LicenseController(ILicenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetLicensesForAccountAsync(string externalAccountId)
        {
            var licenses = await _service.GetLicensesForAccountAsync(externalAccountId);
            var dtos = licenses.Select(LicenseMapper.ToLicenseDto);

            return Ok(licenses);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLicenseAsync(LicenseDto licenseDto)
        {
            var license = LicenseMapper.ToLicense(licenseDto);
            var createdLicense = await _service.CreateLicenseAsync(license);
            var createdLicenseDto = LicenseMapper.ToLicenseDto(createdLicense);

            return Ok(createdLicenseDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLicenseAsync(LicenseDto licenseDto)
        {
            var license = LicenseMapper.ToLicense(licenseDto);
            var updatedSubscription = await _service.UpdateLicenseAsync(license);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLicenseAsync(Guid licenseId)
        {
            var wasDeleted = await _service.DeleteLicenseAsync(licenseId);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
