namespace PropertyManager.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tenants", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tenants", "AddressId", c => c.Int());
        }
    }
}
