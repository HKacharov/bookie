namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Rentals", newName: "Loans");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Loans", newName: "Rentals");
        }
    }
}
