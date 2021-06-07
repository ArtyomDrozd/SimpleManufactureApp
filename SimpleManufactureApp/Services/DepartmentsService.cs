using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleManufactureApp.Data;
using SimpleManufactureApp.Interfaces;
using SimpleManufactureApp.Models;
using SimpleManufactureApp.Validators;

namespace SimpleManufactureApp.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        public List<DepartmentModel> GetAllDepartments()
        {
            using (var context = new ManufactureDbContext())
            {
                var departments = context.Departments.ToList();
                return departments;
            }
        }

        public void CreateDepartment(DepartmentModel createdDepartment)
        {
            using (var context = new ManufactureDbContext())
            {
                var validator = new DepartmentValidator();
                var result = validator.Validate(createdDepartment);

                if (result.IsValid == false)
                {
                    foreach (var failure in result.Errors)
                    {
                      Console.WriteLine($"{failure.ErrorMessage}");
                    }
                    return;
                }

                context.Departments.Add(createdDepartment);
                context.SaveChanges();
            }
        }

        public void UpdateDepartment(int id, DepartmentModel updatedDepartment)
        {
            using (var context = new ManufactureDbContext())
            {
                var validator = new DepartmentValidator();
                var result = validator.Validate(updatedDepartment);
                updatedDepartment.DepartmentId = id;

                if (result.IsValid == false)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine($"{failure.ErrorMessage}");
                    }
                    return;
                }

                context.Entry(updatedDepartment).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteDepartment(int id)
        {
            using (var context = new ManufactureDbContext())
            {
                var department = context.Departments.Find(id);
                context.Departments.Remove(department ?? throw new InvalidOperationException());
                context.SaveChanges();
            }
        }
    }
}
