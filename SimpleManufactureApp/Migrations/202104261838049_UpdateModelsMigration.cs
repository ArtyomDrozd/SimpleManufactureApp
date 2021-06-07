namespace SimpleManufactureApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "DepartmentName", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "MiddleName", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "Position", c => c.String(nullable: false));
            AlterColumn("dbo.Mission", "MissionName", c => c.String(nullable: false));
            AlterColumn("dbo.Mission", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mission", "Description", c => c.String());
            AlterColumn("dbo.Mission", "MissionName", c => c.String());
            AlterColumn("dbo.Employee", "Position", c => c.String());
            AlterColumn("dbo.Employee", "LastName", c => c.String());
            AlterColumn("dbo.Employee", "MiddleName", c => c.String());
            AlterColumn("dbo.Employee", "FirstName", c => c.String());
            AlterColumn("dbo.Department", "DepartmentName", c => c.String());
        }
    }
}
