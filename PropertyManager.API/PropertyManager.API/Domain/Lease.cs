using PropertyManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Domain
{

    public enum RentFrequency
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Quarterly = 4,
        BiAnnually = 5,
        Annually = 6

    }
    public class Lease
    {
        public Lease()
        { }

        public Lease(LeaseModel model)
        {
            this.Update(model);
        }


        public int LeaseId { get; set; }
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rent { get; set; }
        public RentFrequency RentFrequency { get; set; }

        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual PropertyManagerUser User { get; set; }

        public void Update(LeaseModel model)
        {
            LeaseId = model.LeaseId;
            TenantId = model.TenantId;
            PropertyId = model.PropertyId;
            UserId = model.UserId;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Rent = model.Rent;
            RentFrequency = model.RentFrequency;

        }
    }
}