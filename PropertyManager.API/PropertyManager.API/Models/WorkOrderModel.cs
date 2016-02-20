using PropertyManager.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Models
{
    
    public class WorkOrderModel
    {
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        public int? TenantId { get; set; }
        public string Descriptions { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public Priorities Priority { get; set; }

        public TenantModel Tenant { get; set; }
        public PropertyModel Property { get; set; }
    }
}