namespace Crayon.CloudSales.Api.Dtos
{
    public class AccountDto
    {
        public required string ExternalId { get; set; }

        public required string CustomerId { get; set; }

        public required string Name { get; set; }

        public IEnumerable<LicenseDto> Licenses { get; set; } = Enumerable.Empty<LicenseDto>();
    }
}
