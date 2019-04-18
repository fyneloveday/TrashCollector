namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TrashCollectorEmployees", "AspUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrashCollectorEmployees", "AspUserId", c => c.String());
        }
    }
}
