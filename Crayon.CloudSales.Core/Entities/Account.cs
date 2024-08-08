namespace Crayon.CloudSales.Core.Entities
{
    public class Account
    {
        public required string ExternalId { get; set; }

        public required string CustomerId { get; set; }

        public required string Name { get; set; }

        public IEnumerable<License> Licenses { get; set; } = Enumerable.Empty<License>();
    }
}
