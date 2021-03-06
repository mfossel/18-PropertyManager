﻿using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.API.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PropertyManager.API.Infrastructure
{
    public class PropertyManagerDataContext : IdentityDbContext<PropertyManagerUser>
    {
        public PropertyManagerDataContext() : base("PropertyManager")
        {
        }

        //SQL TABLES
        public IDbSet<Lease> Leases { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Tenant> Tenants { get; set; }
        public IDbSet<WorkOrder> WorkOrders { get; set; }
       

        //SQL RELATIONSHIPS
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
     
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
                .HasMany(t => t.WorkOrders)
                .WithOptional(wo => wo.Tenant)
                .HasForeignKey(wo => wo.TenantId);

            modelBuilder.Entity<PropertyManagerUser>()
                .HasMany(u => u.Properties)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.UserId);
                

            modelBuilder.Entity<PropertyManagerUser>()
                .HasMany(u => u.Tenants)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropertyManagerUser>()
                .HasMany(u => u.Leases)
                .WithRequired(l => l.User)
                .HasForeignKey(l => l.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropertyManagerUser>()
                .HasMany(u => u.WorkOrders)
                .WithRequired(wo => wo.User)
                .HasForeignKey(wo => wo.UserId)
                .WillCascadeOnDelete(false);




            //Set up relationships for ASP.NET Identity
            base.OnModelCreating(modelBuilder);
        }

        
    }
}