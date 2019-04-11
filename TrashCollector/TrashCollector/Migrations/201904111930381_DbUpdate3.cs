namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "PickupDay", c => c.Int(nullable: false));
            AddColumn("dbo.TrashCollectorCustomers", "BackupPickupDay", c => c.DateTime(nullable: false));
            DropColumn("dbo.TrashCollectorCustomers", "PickupWeek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrashCollectorCustomers", "PickupWeek", c => c.Int(nullable: false));
            DropColumn("dbo.TrashCollectorCustomers", "BackupPickupDay");
            DropColumn("dbo.TrashCollectorCustomers", "PickupDay");
        }
    }
}
