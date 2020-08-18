namespace Bookie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a2ac5a27-ab92-4a2e-b2ab-459e0162eb9d', N'guest@bookie.com', 0, N'APdQjiZ1czVjRk6hFi4pCww9/o2FKnlgIWe8UFpso4V4d+BrUo0ntr+UeL0fwbI7qA==', N'd04e1492-7887-4bfa-a856-0a7a883bc82c', NULL, 0, 0, NULL, 1, 0, N'guest@bookie.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ec898bc1-81b8-423f-abfe-03e543b43f01', N'admin@bookie.com', 0, N'AJmzJpH3TMLyU9IWfZcsJqWwE9JivEFkS34L8BfMImkT49mlawNjpGcZZdNjOOcruw==', N'd7dc8c29-c7c7-4e73-9a53-dc88714f7246', NULL, 0, 0, NULL, 1, 0, N'admin@bookie.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'96d5b425-e5ed-4f96-be76-349c31328f21', N'CanManageBooks')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ec898bc1-81b8-423f-abfe-03e543b43f01', N'96d5b425-e5ed-4f96-be76-349c31328f21')

");
        }
        
        public override void Down()
        {
        }
    }
}
