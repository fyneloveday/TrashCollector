namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "Street", c => c.String());
            AddColumn("dbo.TrashCollectorCustomers", "State", c => c.String(nullable: false));
            AddColumn("dbo.TrashCollectorCustomers", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.TrashCollectorCustomers", "Long", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorCustomers", "Long");
            DropColumn("dbo.TrashCollectorCustomers", "Lat");
            DropColumn("dbo.TrashCollectorCustomers", "State");
            DropColumn("dbo.TrashCollectorCustomers", "Street");
        }
    }
}
