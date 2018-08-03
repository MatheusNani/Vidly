namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularGerenTypesAgain : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO GenreTypes(Id, Name) VALUES(1,'Fiction') ");
			Sql("INSERT INTO GenreTypes(Id, Name) VALUES(2,'Comedy') ");
			Sql("INSERT INTO GenreTypes(Id, Name) VALUES(3,'Action') ");
			Sql("INSERT INTO GenreTypes(Id, Name) VALUES(4,'Romance') ");
			Sql("INSERT INTO GenreTypes(Id, Name) VALUES(5,'Family') ");
		}
        
        public override void Down()
        {
        }
    }
}
