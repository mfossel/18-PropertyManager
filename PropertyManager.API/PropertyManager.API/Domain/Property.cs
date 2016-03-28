using PropertyManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.API.Domain
{
    public class Property
    {
        public Property()
        { }

        public Property(PropertyModel model)
        {
            this.Update(model);
        }

        public int PropertyId { get; set; }
        public string UserId { get; set; }

        public string PropertyName { get; set; }
        public int? SquareFeet { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public float? NumberOfBathrooms { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual PropertyManagerUser User { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public void Update(PropertyModel model)
        {
            PropertyId = model.PropertyId;
            PropertyName = model.PropertyName;
            SquareFeet = model.SquareFeet;
            NumberOfBedrooms = model.NumberOfBedrooms;
            NumberOfBathrooms = model.NumberOfBathrooms;
            Address1 = model.Address1;
            Address2 = model.Address2;
            Address3 = model.Address3;
            City = model.City;
            State = model.State;
            ZipCode = model.ZipCode;

        }
    }
}