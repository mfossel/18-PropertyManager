using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Models
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

    public class LeaseModel
    {
        public int LeaseId { get; set; }
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rent { get; set; }
        public RentFrequency RentFrequency { get; set; }
    }
}