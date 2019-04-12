namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContexts2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "BackupPickupDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorCustomers", "BackupPickupDay");
        }
    }
}
