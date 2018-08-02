namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTypesToMovies : DbMigration
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
            
            AddColumn("dbo.Movies", "GenreTypesId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreTypesId");
            AddForeignKey("dbo.Movies", "GenreTypesId", "dbo.GenreTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypesId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypesId" });
            DropColumn("dbo.Movies", "GenreTypesId");
            DropTable("dbo.GenreTypes");
        }
    }
}
