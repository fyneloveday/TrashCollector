namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetDb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "PickupWeek", c => c.Int(nullable: false));
            DropColumn("dbo.TrashCollectorCustomers", "PickupDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrashCollectorCustomers", "PickupDay", c => c.String(nullable: false));
            DropColumn("dbo.TrashCollectorCustomers", "PickupWeek");
        }
    }
}
