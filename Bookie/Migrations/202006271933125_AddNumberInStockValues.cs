namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberInStockValues : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Books SET NumberInStock = 5 WHERE Id=2");
            Sql("UPDATE Books SET NumberInStock = 3 WHERE Id=3");
            Sql("UPDATE Books SET NumberInStock = 10 WHERE Id=4");
            Sql("UPDATE Books SET NumberInStock = 7 WHERE Id=5");
            Sql("UPDATE Books SET NumberInStock = 2 WHERE Id=6");
        }
        
        public override void Down()
        {
        }
    }
}
