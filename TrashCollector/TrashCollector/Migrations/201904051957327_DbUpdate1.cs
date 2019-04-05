namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.TrashCollectorCustomers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.TrashCollectorCustomers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.TrashCollectorCustomers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.TrashCollectorEmployees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.TrashCollectorEmployees", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrashCollectorEmployees", "LastName", c => c.String());
            AlterColumn("dbo.TrashCollectorEmployees", "FirstName", c => c.String());
            AlterColumn("dbo.TrashCollectorCustomers", "City", c => c.String());
            AlterColumn("dbo.TrashCollectorCustomers", "LastName", c => c.String());
            AlterColumn("dbo.TrashCollectorCustomers", "FirstName", c => c.String());
            DropColumn("dbo.TrashCollectorCustomers", "State");
        }
    }
}
