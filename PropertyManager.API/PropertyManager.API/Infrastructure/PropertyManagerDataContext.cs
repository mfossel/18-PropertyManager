using PropertyManager.API.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PropertyManager.API.Infrastructure
{
    public class PropertyManagerDataContext : DbContext
    {
        public PropertyManagerDataContext() : base("PropertyManager")
        {
        }

        //SQL TABLES
        public IDbSet<Address> Address { get; set; }
        public IDbSet<Lease> Lease { get; set; }
        public IDbSet<Property> Property { get; set; }
        public IDbSet<Tenant> Tenant { get; set; }
        public IDbSet<WorkOrder> WordOrder { get; set; }

        //SQL RELATIONSHIPS
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(a => a.Properties)
                .WithRequired(p => p.Address);
   
            modelBuilder.Entity<Address>()
                .HasMany(a => a.Tenants)
                .WithRequired(t => t.Address)
                .HasForeignKey(t => t.AddressId);

            modelBuilder.Entity<Property>()
                 .HasMany(p => p.Leases)
                 .WithRequired(l => l.Property)
                 .HasForeignKey(l => l.PropertyId);

            modelBuilder.Entity<Property>()
                .HasMany(p => p.WorkOrders)
                .WithRequired(wo => wo.Property)
                .HasForeignKey(wo => wo.PropertyId);

            modelBuilder.Entity<Tenant>()
                .HasMany(t => t.Leases)
                .WithRequired(l => l.Tenant)
                .HasForeignKey(l => l.TenantId);

            modelBuilder.Entity<Tenant>()
                .HasMany(t=>t.WorkOrders)
                .WithOptional(wo=> wo.Tenant)
                .HasForeignKey(wo=> wo.TenantId)
         




    }
}