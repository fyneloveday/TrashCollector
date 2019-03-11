namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBillProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "Bill", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorCustomers", "Bill");
        }
    }
}
