namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppedColumnInCustomers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
    }
}
