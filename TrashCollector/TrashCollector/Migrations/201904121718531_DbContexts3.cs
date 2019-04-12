namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContexts3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "StartPickupSuspension", c => c.DateTime());
            AddColumn("dbo.TrashCollectorCustomers", "EndPickupSuspension", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorCustomers", "EndPickupSuspension");
            DropColumn("dbo.TrashCollectorCustomers", "StartPickupSuspension");
        }
    }
}
