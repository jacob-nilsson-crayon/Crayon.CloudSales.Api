namespace Crayon.CloudSales.Core.Entities
{
    public class License
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string ExternalSoftwareProductId { get; set; }

        public required string ExternalAccountId { get; set; }

        public required DateTime ValidTo { get; set; }

        public required bool IsActive { get; set; }
    }
}
