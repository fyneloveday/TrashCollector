namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorEmployees", "AspUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorEmployees", "AspUserId");
        }
    }
}
