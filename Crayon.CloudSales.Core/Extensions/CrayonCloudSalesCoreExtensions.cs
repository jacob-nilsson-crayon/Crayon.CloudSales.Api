using Crayon.CloudSales.Core.Interfaces.Services;
using Crayon.CloudSales.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Crayon.CloudSales.Core.Extensions
{
    public static class CrayonCloudSalesCoreExtensions
    {
        public static IServiceCollection AddCrayonCloudSalesCore(this IServiceCollection services)
        {
            services.AddScoped<ISoftwareProductService, SoftwareProductService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILicenseService, LicenseService>();

            return services;
        }
    }
}
