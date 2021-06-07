namespace SimpleManufactureApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employee", "IdMission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "IdMission", c => c.Int(nullable: false));
        }
    }
}
