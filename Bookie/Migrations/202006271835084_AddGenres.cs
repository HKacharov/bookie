namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Science-Fiction')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Fiction')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Educational')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Mystery')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (5, 'Kids')");
        }
        
        public override void Down()
        {
        }
    }
}
