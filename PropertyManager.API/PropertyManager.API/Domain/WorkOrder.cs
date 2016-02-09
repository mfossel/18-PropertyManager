using PropertyManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Domain
{
    public enum Priorities
    {
        Emergency = 5,
        High = 4,
        Medium = 3,
        Low = 2,
        Routine = 1
    }

    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        public int? TenantId { get; set; }
        public string Descriptions { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public Priorities Priority { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual Property Property { get; set; }


        public void Update(WorkOrderModel model)
        {
            WorkOrderId = model.WorkOrderId;
            PropertyId = model.PropertyId;
            TenantId = model.TenantId;
            Descriptions = model.Descriptions;
            OpenDate = model.OpenDate;
            ClosedDate = model.ClosedDate;
            Priority = model.Priority;
        }
    }
}