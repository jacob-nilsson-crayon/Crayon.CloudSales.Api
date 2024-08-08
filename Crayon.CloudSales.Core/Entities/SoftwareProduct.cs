namespace Crayon.CloudSales.Core.Entities
{
    public class SoftwareProduct
    {
        public required string ExternalId { get; set; }

        public required string Name { get; set; }

        public required decimal ExternalPrice { get; set; }
    }
}
