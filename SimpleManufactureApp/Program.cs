using System;
using System.Collections.Generic;
using SimpleManufactureApp.Interfaces;
using SimpleManufactureApp.Models;
using SimpleManufactureApp.Services;
using static System.Console;


namespace SimpleManufactureApp
{
    internal class Program
    {
        private static readonly IDepartmentsService DepartmentsService = new DepartmentsService();
        private static readonly IEmployeesService EmployeesService = new EmployeeService();
        private static readonly IMissionsService MissionsService = new MissionsService();

        private static void Main(string[] args)
        {
            var showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        public static bool MainMenu()
        {
            Clear();
            WriteLine("Choose an option:");
            WriteLine("1. Employee Data");
            WriteLine("2. Mission Data");
            WriteLine("3. Department Data");
            WriteLine("4. Exit");
            Write("\r\nSelect an option: ");

            switch (ReadLine())
            {
                case "1":
                    EmployeeMenu();
                    return true;
                case "2":
                    MissionMenu();
                    return true;
                case "3":
                    DepartmentMenu();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        public static bool EmployeeMenu()
        {
            Clear();
            var employee = EmployeesService.GetAllEmployees();
            ShowEmployeeData(employee);
            WriteLine("Choose an option:");
            WriteLine("1. Create");
            WriteLine("2. Update");
            WriteLine("3. Delete");
            WriteLine("4. Add Mission to Employee");
            WriteLine("5. Back to Main Menu");
            Write("\r\nSelect an option: ");

            switch (ReadLine())
            {
                case "1":
                    var createdEmployee = SetEmployeeData();
                    EmployeesService.CreateEmployee(createdEmployee);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "2":
                    WriteLine("Enter ID of Employee to update");
                    var updateId = int.Parse(ReadLine());
                    var updatedEmployee = SetEmployeeData();
                    EmployeesService.UpdateEmployee(updateId, updatedEmployee);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "3":
                    WriteLine("Enter ID of Employee to delete");
                    var deleteId = int.Parse(ReadLine());
                    EmployeesService.DeleteEmployee(deleteId);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "4":
                    WriteLine("Enter ID of Employee to add Mission");
                    var employeeId = int.Parse(ReadLine());
                    var missions = MissionsService.GetAllMissions();
                    WriteLine("Mission ID \t Mission Name");
                    foreach (var mission in missions)
                    {
                        WriteLine("{0} \t {1}", mission.MissionId,mission.MissionName);
                    }
                    WriteLine("---------------");
                    WriteLine("Select ID of Mission");
                    var missionId = int.Parse(ReadLine());
                    EmployeesService.AddMission(employeeId,missionId);
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }

        private static EmployeeModel SetEmployeeData()
        {
            var employee = new EmployeeModel();

            WriteLine("Enter Employee First Name");
            employee.FirstName = ReadLine();
            WriteLine("Enter Employee Middle Name");
            employee.MiddleName = ReadLine();
            WriteLine("Enter Employee Last Name");
            employee.LastName = ReadLine();
            WriteLine("Enter Employee Position");
            employee.Position = ReadLine();
            WriteLine("Enter Employee Birth Date");
            employee.BirthDate = DateTime.Parse(ReadLine());
            WriteLine("Enter Department ID");
            employee.DepartmentId = int.Parse(ReadLine());

            return employee;
        }

        public static void ShowEmployeeData(IEnumerable<EmployeeModel> employees)
        {
            WriteLine("Employee ID \t First Name \t Middle Name \t Last Name \t Position \t Birth Date \t Department ID " +
                      "\t Mission Name \t Mission Description");
            foreach (var employee in employees)
            {
                WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t", employee.EmployeeId, employee.FirstName, employee.MiddleName
                    , employee.LastName, employee.Position, employee.BirthDate.ToShortDateString(), employee.DepartmentId);
                foreach (var mission in employee.Missions)
                {
                    Write("{0} \t {1}", mission.MissionName,mission.Description);
                }
            }
        }

        public static bool MissionMenu()
        {
            Clear();
            var mission = MissionsService.GetAllMissions();
            ShowMissionsData(mission);
            WriteLine("Choose an option:");
            WriteLine("1. Create");
            WriteLine("2. Update");
            WriteLine("3. Delete");
            WriteLine("4. Back to Main Menu");
            Write("\r\nSelect an option: ");

            switch (ReadLine())
            {
                case "1":
                    var createdMission = SetMissionData();
                    MissionsService.CreateMission(createdMission);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "2":
                    WriteLine("Enter ID of mission to update");
                    var updateId = int.Parse(ReadLine());
                    var updatedMission = SetMissionData();
                    MissionsService.UpdateMission(updateId, updatedMission);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "3":
                    WriteLine("Enter ID of mission to delete");
                    var deleteId = int.Parse(ReadLine());
                    MissionsService.DeleteMission(deleteId);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        private static MissionModel SetMissionData()
        {
            var mission = new MissionModel();

            WriteLine("Enter Mission Name");
            mission.MissionName = ReadLine();
            WriteLine("Enter Description");
            mission.Description = ReadLine();
            WriteLine("Enter Start Date (yyyy-mm-dd)");
            mission.StartDate = DateTime.Parse(ReadLine());
            WriteLine("Enter End Date (yyyy-mm-dd)");
            mission.EndDate = DateTime.Parse(ReadLine());

            return mission;
        }

        private static void ShowMissionsData(IEnumerable<MissionModel> missions)
        {
            WriteLine("Mission ID \t Mission Name \t Description \t Start Date \t End Date");
            foreach (var mission in missions)
            {
                WriteLine("{0} \t {1} \t {2} \t {3} \t {4}", mission.MissionId, mission.MissionName, mission.Description
                    , mission.StartDate.ToShortDateString(), mission.EndDate.ToShortDateString());
            }
        }

        public static bool DepartmentMenu()
        {
            Clear();
            var department = DepartmentsService.GetAllDepartments();
            ShowDepartmentsData(department);
            WriteLine("Choose an option:");
            WriteLine("1. Create");
            WriteLine("2. Update");
            WriteLine("3. Delete");
            WriteLine("4. Back to Main Menu");
            Write("\r\nSelect an option: ");

            switch (ReadLine())
            {
                case "1":
                    var createdDepartment = SetDepartmentData();
                    DepartmentsService.CreateDepartment(createdDepartment);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "2":
                    WriteLine("Enter ID of student to update");
                    var updateId = int.Parse(ReadLine());
                    var updatedDepartment = SetDepartmentData();
                    DepartmentsService.UpdateDepartment(updateId, updatedDepartment);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "3":
                    WriteLine("Enter ID of student to delete");
                    var deleteId = int.Parse(ReadLine());
                    DepartmentsService.DeleteDepartment(deleteId);
                    Write("\r\nPress Enter to return to Main Menu");
                    ReadLine();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        private static DepartmentModel SetDepartmentData()
        {
            var department = new DepartmentModel();

            WriteLine("Enter Department Name");
            department.DepartmentName = ReadLine();

            return department;
        }

        private static void ShowDepartmentsData(IEnumerable<DepartmentModel> departments)
        {
            WriteLine("Department ID \t Department Name");
            foreach (var department in departments)
            {
                WriteLine("{0} \t {1}", department.DepartmentId, department.DepartmentName);
            }
        }
    }
}
