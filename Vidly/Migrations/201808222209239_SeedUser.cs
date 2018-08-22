namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
			Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'172f9da5-99fc-45e8-b28e-33c0bc13e9ad', N'guest@vidly.com', 0, N'AGSw1kCjbqH6UHGr23QvjWWntPL3pNlU6agXJBDt28gldkaBG9jDpY34WC42oU4jsQ==', N'4261c51f-b981-47f4-a374-5d8e4fcabc14', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f4a64a8e-6981-4a16-aa6c-c4f61b26fa80', N'admin@vidly.com', 0, N'AEDehcjUovftZeGiJe/ohCxB7R2Y054NIltNy8Den8t4owMgqi9jmuohzO4M9qQ9hg==', N'b6eec225-a850-455b-9bf7-1c04d608da70', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9e28a494-eeb0-43e6-b17c-2dd34c887dbd', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f4a64a8e-6981-4a16-aa6c-c4f61b26fa80', N'9e28a494-eeb0-43e6-b17c-2dd34c887dbd')


");
        }
        
        public override void Down()
        {
        }
    }
}
