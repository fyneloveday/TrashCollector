namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId");
            AddForeignKey("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId", "dbo.TrashCollectorCustomers", "Id", cascadeDelete: true);
            DropColumn("dbo.TrashCollectorEmployees", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrashCollectorEmployees", "ZipCode", c => c.Int(nullable: false));
            DropForeignKey("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId", "dbo.TrashCollectorCustomers");
            DropIndex("dbo.TrashCollectorEmployees", new[] { "TrashCollectorCustomerId" });
            DropColumn("dbo.TrashCollectorEmployees", "TrashCollectorCustomerId");
        }
    }
}
