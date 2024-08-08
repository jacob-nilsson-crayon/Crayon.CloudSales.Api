using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.CloudSales.Core.Entities
{
    public class OrderResponse
    {
        public required string ExternalAccountId { get; set; }

        public IEnumerable<SoftwareProduct> SoftwareProducts { get; set; }
    }
}
