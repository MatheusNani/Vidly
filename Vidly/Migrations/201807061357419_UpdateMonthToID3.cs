namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMonthToID3 : DbMigration
    {
        public override void Up()
        {
			Sql("UPDATE MembershipTypes SET DurationInMonths = 3 where Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
