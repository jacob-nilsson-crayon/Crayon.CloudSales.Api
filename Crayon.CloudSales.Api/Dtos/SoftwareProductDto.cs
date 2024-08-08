namespace Crayon.CloudSales.Api.Dtos
{
    public class SoftwareProductDto
    {
        public required string ExternalId { get; set; }

        public required string Name { get; set; }

        public required decimal ExternalPrice { get; set; }
    }
}
