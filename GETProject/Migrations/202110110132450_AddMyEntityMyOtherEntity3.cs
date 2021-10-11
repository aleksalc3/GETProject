namespace GETProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyEntityMyOtherEntity3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserId" });
            AlterColumn("dbo.Tasks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "UserId");
            AddForeignKey("dbo.Tasks", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "UserId" });
            AlterColumn("dbo.Tasks", "UserId", c => c.Int());
            CreateIndex("dbo.Tasks", "UserId");
            AddForeignKey("dbo.Tasks", "UserId", "dbo.Users", "Id");
        }
    }
}
