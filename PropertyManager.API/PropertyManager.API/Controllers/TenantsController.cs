﻿using System;
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
    [Authorize]
    public class TenantsController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Tenants
        public IEnumerable<TenantModel> GetTenants()
        {
            return Mapper.Map<IEnumerable<TenantModel>>(
                db.Tenants.Where(t=> t.User.UserName == User.Identity.Name)
                );
        }

        // GET: api/TenantsCount
        [Route("api/Tenants/count")]
        public int GetTenantsCount()
        {
            int count = db.Tenants.Where(t => t.User.UserName == User.Identity.Name).Count();

            return count;
        }

        // GET: api/NewTenants
        [Route("api/tenants/new")]
        public IEnumerable<TenantModel> GetNewTenants()
        {
            var newTenants = db.Tenants.Where(t => t.User.UserName == User.Identity.Name)
                                                .OrderBy(t => t.TenantId)
                                                .Take(5);

            return Mapper.Map<IEnumerable<TenantModel>>(newTenants);
        }

        // GET: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult GetTenant(int id)
        {
            //  Tenant tenant = db.Tenants.Find(id);

            Tenant tenant = db.Tenants.FirstOrDefault(t => t.User.UserName == User.Identity.Name && t.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        // PUT: api/Tenants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenant(int id, TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenant.TenantId)
            {
                return BadRequest();
            }

            // var dbTenant = db.Tenants.Find(id);
            Tenant dbTenant = db.Tenants.FirstOrDefault(t => t.User.UserName == User.Identity.Name && t.TenantId == id);
            if (dbTenant==null)
            {
                return BadRequest();
            }

            dbTenant.Update(tenant);
            db.Entry(dbTenant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
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

        // POST: api/Tenants
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult PostTenant(TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbTenant = new Tenant(tenant);
            dbTenant.User = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);


            db.Tenants.Add(dbTenant);
            db.SaveChanges();


            tenant.TenantId = dbTenant.TenantId;


            return CreatedAtRoute("DefaultApi", new { id = tenant.TenantId }, tenant);
        }

        // DELETE: api/Tenants/5
        [ResponseType(typeof(Tenant))]
        public IHttpActionResult DeleteTenant(int id)
        {
            Tenant tenant = db.Tenants.FirstOrDefault(t => t.User.UserName == User.Identity.Name && t.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            db.SaveChanges();

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(int id)
        {
            return db.Tenants.Count(e => e.TenantId == id) > 0;
        }
    }
}