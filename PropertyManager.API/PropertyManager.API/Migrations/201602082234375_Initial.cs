namespace PropertyManager.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        PropertyName = c.String(),
                        SquareFeet = c.Int(),
                        NumberOfBedrooms = c.Int(),
                        NumberOfBathrooms = c.Single(),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Leases",
                c => new
                    {
                        LeaseId = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentFrequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaseId)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.TenantId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        TenantId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        TelephoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.TenantId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        TenantId = c.Int(),
                        Descriptions = c.String(),
                        OpenDate = c.DateTime(nullable: false),
                        ClosedDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Tenants", t => t.TenantId)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenants", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Properties", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.WorkOrders", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Leases", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.WorkOrders", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.Leases", "TenantId", "dbo.Tenants");
            DropIndex("dbo.WorkOrders", new[] { "TenantId" });
            DropIndex("dbo.WorkOrders", new[] { "PropertyId" });
            DropIndex("dbo.Tenants", new[] { "AddressId" });
            DropIndex("dbo.Leases", new[] { "PropertyId" });
            DropIndex("dbo.Leases", new[] { "TenantId" });
            DropIndex("dbo.Properties", new[] { "AddressId" });
            DropTable("dbo.WorkOrders");
            DropTable("dbo.Tenants");
            DropTable("dbo.Leases");
            DropTable("dbo.Properties");
            DropTable("dbo.Addresses");
        }
    }
}
