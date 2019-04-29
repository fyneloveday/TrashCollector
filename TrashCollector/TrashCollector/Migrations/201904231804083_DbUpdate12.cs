namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorEmployees", "PickupStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorEmployees", "PickupStatus");
        }
    }
}
