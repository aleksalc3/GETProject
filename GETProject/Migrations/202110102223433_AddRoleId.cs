namespace GETProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Int());
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            Sql(@"UPDATE dbo.Users SET RoleId = 1
              where RoleId IS NULL");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropColumn("dbo.Users", "RoleId");
        }
    }
}
