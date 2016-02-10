using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PropertyManager.API.Domain;
using PropertyManager.API.Infrastructure;
using PropertyManager.API.Models;
using AutoMapper;

namespace PropertyManager.API.Controllers
{
    public class AddressesController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Addresses
        public IEnumerable<AddressModel> GetAddresses()
        {
            return Mapper.Map<IEnumerable<AddressModel>>(db.Addresses);
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddressModel))]
        public IHttpActionResult GetAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<AddressModel>(address));
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, AddressModel address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.AddressId)
            {
                return BadRequest();
            }

            var dbAddress = db.Addresses.Find(id);
            

            db.Entry(address).State = EntityState.Modified;
            dbAddress.Update(address);
            db.Entry(dbAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ResponseType(typeof(AddressModel))]
        public IHttpActionResult PostAddress(AddressModel address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbAddress = new Address(address);

            db.Addresses.Add(dbAddress);
            db.SaveChanges();
            address.AddressId = dbAddress.AddressId;

            return CreatedAtRoute("DefaultApi", new { id = address.AddressId }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return Ok(Mapper.Map<AddressModel>(address));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.AddressId == id) > 0;
        }
    }
}