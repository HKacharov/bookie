namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCOlumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "DateLoaned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Loans", "DateRented");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "DateRented", c => c.DateTime(nullable: false));
            DropColumn("dbo.Loans", "DateLoaned");
        }
    }
}
