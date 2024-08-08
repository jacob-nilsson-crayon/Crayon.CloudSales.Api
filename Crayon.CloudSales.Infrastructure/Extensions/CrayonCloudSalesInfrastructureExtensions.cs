using Crayon.CloudSales.Core.Interfaces.Gateways;
using Crayon.CloudSales.Core.Interfaces.Repositories;
using Crayon.CloudSales.Core.Interfaces.Services;
using Crayon.CloudSales.Core.Services;
using Crayon.CloudSales.Infrastructure.Gateways;
using Crayon.CloudSales.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.CloudSales.Infrastructure.Extensions
{
    public static class CrayonCloudSalesInfrastructureExtensions
    {
        public static IServiceCollection AddCrayonCloudSalesInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CrayonCloudSalesDbContext>();
            services.AddDbContext<CrayonCloudSalesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));



            services.AddScoped<ICloudComputingProviderGateway, CloudComputingProviderGateway>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();

            return services;
        }
    }
}
