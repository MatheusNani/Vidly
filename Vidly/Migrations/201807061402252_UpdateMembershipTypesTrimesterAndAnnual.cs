namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypesTrimesterAndAnnual : DbMigration
    {
        public override void Up()
        {
			Sql("UPDATE MembershipTypes SET Name = 'Trimester' where Id = 3 ");
			Sql("UPDATE MembershipTypes SET Name = 'Annual' where Id = 4 ");
		}
        
        public override void Down()
        {
        }
    }
}
