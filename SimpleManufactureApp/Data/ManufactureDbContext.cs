using System.Data.Entity;
using SimpleManufactureApp.Models;

namespace SimpleManufactureApp.Data
{
    public class ManufactureDbContext:DbContext
    {
        public ManufactureDbContext() : base("name=DBConnection") { }

        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<MissionModel> Missions { get; set; }
    }
}
