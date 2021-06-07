using System.Collections.Generic;
using SimpleManufactureApp.Models;

namespace SimpleManufactureApp.Interfaces
{
    public interface IEmployeesService
    {
        List<EmployeeModel> GetAllEmployees();
        void CreateEmployee(EmployeeModel createdEmployee);
        void UpdateEmployee(int id, EmployeeModel updatedEmployee);
        void DeleteEmployee(int id);
        void AddMission(int employeeId, int missionId);
    }
}
