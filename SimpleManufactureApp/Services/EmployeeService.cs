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
    internal class EmployeeService : IEmployeesService
    {
        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new ManufactureDbContext())
            {
                var employee = context.Employees.Include(c =>c.Missions).ToList();
                return employee;
            }
        }

        public void CreateEmployee(EmployeeModel createdEmployee)
        {
            using (var context = new ManufactureDbContext())
            {
                var validator = new EmployeeValidator();
                var result = validator.Validate(createdEmployee);

                if (result.IsValid == false)
                {
                    foreach (var failure in result.Errors)
                    {
                     Console.WriteLine($"{failure.ErrorMessage}");   
                    }
                    return;
                }

                context.Employees.Add(createdEmployee);
                context.SaveChanges();
            }
        }

        public void UpdateEmployee(int id,EmployeeModel updatedEmployee)
        {
            using (var context = new ManufactureDbContext())
            {
                var validator = new EmployeeValidator();
                var result = validator.Validate(updatedEmployee);
                updatedEmployee.EmployeeId = id;

                if (result.IsValid == false)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine($"{failure.ErrorMessage}");
                    }
                    return;
                }

                context.Entry(updatedEmployee).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void AddMission(int employeeId, int missionId)
        {
            using (var context = new ManufactureDbContext())
            {
                var employee = context.Employees.Find(employeeId);
                var mission = context.Missions.Find(missionId);
                employee?.Missions.Add(mission);
                context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var context = new ManufactureDbContext())
            {
                var employee = context.Employees.Find(id);
                context.Employees.Remove(employee ?? throw new InvalidOperationException());
                context.SaveChanges();
            }
        }
    }
}
