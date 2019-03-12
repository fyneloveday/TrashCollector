namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcustomeraspuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrashCollectorCustomers", "AspUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrashCollectorCustomers", "AspUserId");
        }
    }
}
