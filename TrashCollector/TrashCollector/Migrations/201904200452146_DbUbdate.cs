namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUbdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrashCollectorEmployees", "AspUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrashCollectorEmployees", "AspUserId", c => c.String(nullable: false));
        }
    }
}
