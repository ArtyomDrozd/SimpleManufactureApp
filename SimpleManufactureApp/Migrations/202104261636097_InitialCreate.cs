namespace SimpleManufactureApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        IdMission = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
