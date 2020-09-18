namespace GigHubBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id, Name) VALUES (1, 'Rock')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (2, 'Pop')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (3, 'Country')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (4, 'Techno')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (5, 'Hip Hop')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM GENRES WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
