using PropertyManager.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PropertyManager.API.Models
{
  

    public class LeaseModel
    {
        public int LeaseId { get; set; }
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rent { get; set; }
        public RentFrequency RentFrequency { get; set; }

        public TenantModel Tenant { get; set; }
        public PropertyModel Property { get; set; }
    }
}