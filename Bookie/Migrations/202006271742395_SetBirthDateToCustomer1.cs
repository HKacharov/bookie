namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthDateToCustomer1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '1988-05-25' WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
