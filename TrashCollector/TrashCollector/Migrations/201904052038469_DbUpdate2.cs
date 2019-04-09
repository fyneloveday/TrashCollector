namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "PickupDay", c => c.String(nullable: false));
            DropColumn("dbo.TrashCollectorCustomers", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrashCollectorCustomers", "State", c => c.String(nullable: false));
            DropColumn("dbo.TrashCollectorCustomers", "PickupDay");
        }
    }
}
