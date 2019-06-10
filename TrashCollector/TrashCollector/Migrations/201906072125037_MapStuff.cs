namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapStuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrashCollectorCustomers", "Lat", c => c.Single(nullable: false));
            AlterColumn("dbo.TrashCollectorCustomers", "Long", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrashCollectorCustomers", "Long", c => c.Double(nullable: false));
            AlterColumn("dbo.TrashCollectorCustomers", "Lat", c => c.Double(nullable: false));
        }
    }
}
