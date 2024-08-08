using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.CloudSales.Infrastructure.Database.Entities
{
    public class LicenseEntity
    {
        public Guid Id { get; set; }

        public string ExternalSoftwareProductId { get; set; }

        public string ExternalAccountId { get; set; }

        public DateTime ValidTo { get; set; }

        public bool IsActive { get; set; }
    }
}
