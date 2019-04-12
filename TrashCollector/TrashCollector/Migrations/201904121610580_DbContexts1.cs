namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContexts1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TrashCollectorCustomers", "BackupPickupDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrashCollectorCustomers", "BackupPickupDay", c => c.DateTime(nullable: false));
        }
    }
}
