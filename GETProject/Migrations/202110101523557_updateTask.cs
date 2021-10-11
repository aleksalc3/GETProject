namespace GETProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTask : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Status", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tasks", "description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "description", c => c.String());
            AlterColumn("dbo.Tasks", "Status", c => c.String());
        }
    }
}
