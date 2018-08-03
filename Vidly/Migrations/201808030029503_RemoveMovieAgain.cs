namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMovieAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypes_Id" });
            DropTable("dbo.Movies");
            DropTable("dbo.GenreTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        ReleasedDate = c.DateTime(),
                        AddedDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        GenreId = c.Byte(nullable: false),
                        GenreTypes_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movies", "GenreTypes_Id");
            AddForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes", "Id");
        }
    }
}
