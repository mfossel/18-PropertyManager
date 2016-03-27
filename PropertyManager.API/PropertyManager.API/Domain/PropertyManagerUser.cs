using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Domain
{
    public class PropertyManagerUser : IdentityUser
    {
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

    }
}