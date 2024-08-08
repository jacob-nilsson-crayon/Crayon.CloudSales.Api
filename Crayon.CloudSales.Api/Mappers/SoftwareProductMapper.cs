using Crayon.CloudSales.Api.Dtos;
using Crayon.CloudSales.Core.Entities;

namespace Crayon.CloudSales.Api.Mappers
{
    internal class SoftwareProductMapper
    {
        internal static SoftwareProductDto ToSoftwareProductDto(SoftwareProduct softwareProduct)
        {
            return new SoftwareProductDto
            {
                ExternalId = softwareProduct.ExternalId,
                ExternalPrice = softwareProduct.ExternalPrice,
                Name = softwareProduct.Name,
            };
        }

        internal static SoftwareProduct ToLicense(SoftwareProductDto softwareProductDto)
        {
            return new SoftwareProduct
            {
                ExternalId = softwareProductDto.ExternalId,
                ExternalPrice = softwareProductDto.ExternalPrice,
                Name = softwareProductDto.Name,
            };
        }
    }
}
