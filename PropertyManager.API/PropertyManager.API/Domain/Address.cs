using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropertyManager.API.Models;

namespace PropertyManager.API.Domain
{
    public class Address
    {

        public Address()
        { }

        public Address(AddressModel model)
        {
            this.Update(model);
        }
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }




        public void Update(AddressModel model)
        {
            Address1 = model.Address1;
            Address2 = model.Address2;
            Address3 = model.Address3;
            City = model.City;
            State = model.State;
            ZipCode = model.ZipCode;
        }

    }
}