namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrashCollectorEmployees", "AspUserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrashCollectorEmployees", "AspUserId", c => c.String());
        }
    }
}
