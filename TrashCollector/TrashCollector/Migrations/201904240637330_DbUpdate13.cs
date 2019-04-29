namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "PickupStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorCustomers", "PickupStatus");
        }
    }
}
