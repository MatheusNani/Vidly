namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
			Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' where Id = 1 ");
			Sql("UPDATE MembershipTypes SET Name = 'Monthly' where Id = 2 ");
			
        }
        
        public override void Down()
        {
        }
    }
}
