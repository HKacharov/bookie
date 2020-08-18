namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberInStockToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberInStock");
        }
    }
}
