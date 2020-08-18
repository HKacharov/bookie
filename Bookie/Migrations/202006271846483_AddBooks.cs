namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooks : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Books(Name, Author, GenreId, DateAdded) VALUES ('Childhoods End', 'Arthur C. Clarke', 1, CURRENT_TIMESTAMP)");
            Sql("INSERT INTO Books(Name, Author, GenreId, DateAdded) VALUES ('Enders Game', 'Orson Scott Card', 1, CURRENT_TIMESTAMP)");
            Sql("INSERT INTO Books(Name, Author, GenreId, DateAdded) VALUES ('Dune', 'Frank Herbert', 1, CURRENT_TIMESTAMP)");
            Sql("INSERT INTO Books(Name, Author, GenreId, DateAdded) VALUES ('Foundation', 'Isaac Asimov', 1, CURRENT_TIMESTAMP)");
            Sql("INSERT INTO Books(Name, Author, GenreId, DateAdded) VALUES ('A Short History of Nearly Everything', 'Bill Bryson', 3, CURRENT_TIMESTAMP)");
        }
        
        public override void Down()
        {
        }
    }
}
