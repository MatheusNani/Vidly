namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDelinquentFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Isdelinquent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Isdelinquent");
        }
    }
}
