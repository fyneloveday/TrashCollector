namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorEmployees", "RouteDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorEmployees", "RouteDay");
        }
    }
}
