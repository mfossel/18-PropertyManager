using PropertyManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Domain
{
    public class Tenant
    {
        public Tenant()
        { }

        public Tenant(TenantModel model)
        {
            this.Update(model);
        }


        public int TenantId { get; set; }
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        
        public virtual PropertyManagerUser User { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public void Update(TenantModel model)
        {
            TenantId = model.TenantId;
            FirstName = model.FirstName;
            LastName = model.LastName;
            TelephoneNumber = model.TelephoneNumber;
            Email = model.Email;

        }
    }
}