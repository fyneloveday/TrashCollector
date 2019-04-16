namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId", "dbo.TrashCollectorCustomers");
            DropIndex("dbo.TrashCollectorEmployees", new[] { "TrashCollectorCustomerId" });
            AddColumn("dbo.TrashCollectorEmployees", "RouteZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.TrashCollectorEmployees", "RouteZipCode");
            CreateIndex("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId");
            AddForeignKey("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId", "dbo.TrashCollectorCustomers", "Id", cascadeDelete: true);
        }
    }
}
