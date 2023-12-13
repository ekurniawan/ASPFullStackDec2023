using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;

namespace SampleASPCore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Departments.Any())
            {
                return;
            }

            var departments = new Department[]{
                new Department {DepartmentName="HR"},
                new Department {DepartmentName="IT"},
                new Department {DepartmentName="Finance"}
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var employees = new Employee[]{
                new Employee {DepartmentID=departments[0].DepartmentID, FullName="Erick Kurniawan",Email="erick@gmail.com",Address="Jogja"},
                new Employee {DepartmentID=departments[1].DepartmentID,FullName="Scott Guthrie",Email="scott@gmail.com",Address="Seattle, WA"}
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}