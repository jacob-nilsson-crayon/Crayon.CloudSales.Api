using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.CloudSales.Infrastructure.Database.Entities
{
    public class AccountEntity
    {
        public string ExternalId { get; set; }

        public string CustomerId { get; set; }

        public string Name { get; set; }

        public List<LicenseEntity> Licenses { get; set; } = new List<LicenseEntity>();
    }
}
