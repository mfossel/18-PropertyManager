using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Domain
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        
        public Address Address { get; set; }

        public ICollection<Lease> Leases { get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; }

    }
}