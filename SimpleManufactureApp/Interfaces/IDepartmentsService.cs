using System.Collections.Generic;
using SimpleManufactureApp.Models;

namespace SimpleManufactureApp.Interfaces
{
    public interface IDepartmentsService
    {
        List<DepartmentModel> GetAllDepartments();
        void CreateDepartment(DepartmentModel createdDepartment);
        void UpdateDepartment(int id, DepartmentModel updatedDepartment);
        void DeleteDepartment(int id);
    }
}
