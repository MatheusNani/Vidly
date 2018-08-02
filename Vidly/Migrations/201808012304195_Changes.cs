namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreTypesId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypesId" });
            RenameColumn(table: "dbo.Movies", name: "GenreTypesId", newName: "GenreTypes_Id");
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "GenreTypes_Id", c => c.Byte());
            CreateIndex("dbo.Movies", "GenreTypes_Id");
            AddForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypes_Id", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypes_Id" });
            AlterColumn("dbo.Movies", "GenreTypes_Id", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
            RenameColumn(table: "dbo.Movies", name: "GenreTypes_Id", newName: "GenreTypesId");
            CreateIndex("dbo.Movies", "GenreTypesId");
            AddForeignKey("dbo.Movies", "GenreTypesId", "dbo.GenreTypes", "Id", cascadeDelete: true);
        }
    }
}
