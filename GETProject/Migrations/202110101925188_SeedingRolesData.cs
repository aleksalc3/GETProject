namespace GETProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingRolesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles(MyPropTitle) VALUES('Administrator')");
            Sql("INSERT INTO Roles(MyPropTitle) VALUES('Project Manager')");
            Sql("INSERT INTO Roles(MyPropTitle) VALUES('Developer')");
        }
        
        public override void Down()
        {
        }
    }
}
