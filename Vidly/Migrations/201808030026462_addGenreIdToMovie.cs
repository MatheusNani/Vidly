namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenreIdToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "GenreTypes_Id", c => c.Byte());
            CreateIndex("dbo.Movies", "GenreTypes_Id");
            AddForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypes_Id" });
            DropColumn("dbo.Movies", "GenreTypes_Id");
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.GenreTypes");
        }
    }
}
