namespace SimpleManufactureApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMissionMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mission",
                c => new
                    {
                        MissionId = c.Int(nullable: false, identity: true),
                        MissionName = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MissionId);
            
            CreateTable(
                "dbo.MissionModelEmployeeModels",
                c => new
                    {
                        MissionModel_MissionId = c.Int(nullable: false),
                        EmployeeModel_EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MissionModel_MissionId, t.EmployeeModel_EmployeeID })
                .ForeignKey("dbo.Mission", t => t.MissionModel_MissionId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeModel_EmployeeID, cascadeDelete: true)
                .Index(t => t.MissionModel_MissionId)
                .Index(t => t.EmployeeModel_EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MissionModelEmployeeModels", "EmployeeModel_EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.MissionModelEmployeeModels", "MissionModel_MissionId", "dbo.Mission");
            DropIndex("dbo.MissionModelEmployeeModels", new[] { "EmployeeModel_EmployeeID" });
            DropIndex("dbo.MissionModelEmployeeModels", new[] { "MissionModel_MissionId" });
            DropTable("dbo.MissionModelEmployeeModels");
            DropTable("dbo.Mission");
        }
    }
}
