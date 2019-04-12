namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrashCollectorCustomers", "BackupPickupDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrashCollectorCustomers", "BackupPickupDay", c => c.DateTime(nullable: false));
        }
    }
}
