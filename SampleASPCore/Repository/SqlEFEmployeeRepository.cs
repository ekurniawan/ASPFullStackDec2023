using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleASPCore.Data;
using SampleASPCore.Models;

namespace SampleASPCore.Repository
{
    public class SqlEFEmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _dbContext;
        public SqlEFEmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee Add(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return employee;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException.Message}");
            }
        }

        public void AddEmployeeWithDepartment()
        {
            /*Department newDepartment = new Department
            {
                DepartmentName = "Procurement"
            };
            _dbContext.Departments.Add(newDepartment);

            var addEmployee = new Employee
            {
                FullName = "Budi",
                Email = "budi@gmail.com",
                Address = "jogja",
                Department = newDepartment
            };
            _dbContext.Employees.Add(addEmployee);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }*/

            //bulk insert
            /*_dbContext.AddRange(new Department { DepartmentName = "Department A" },
            new Department { DepartmentName = "Department B" }, new Department { DepartmentName = "Department C" },
            new Department { DepartmentName = "Department D" }, new Department { DepartmentName = "Department E" });
            _dbContext.SaveChanges();*/

            var departments = _dbContext.Departments;
            foreach (var dept in departments)
            {
                dept.DepartmentName = $"Dept - {dept.DepartmentName}";
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var deleteEmp = GetById(id);
                _dbContext.Employees.Remove(deleteEmp);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException.Message}");
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            //var employees = _dbContext.Employees.OrderBy(e => e.FullName);
            /*var employees = from e in _dbContext.Employees
                            orderby e.FullName
                            select e;*/
            //var employees = _dbContext.Employees.Include(nameof(Department));
            /*var employees = from e in _dbContext.Employees
                            join d in _dbContext.Departments on e.DepartmentID equals d.DepartmentID
                            select new Employee
                            {
                                EmployeeID = e.EmployeeID,
                                FullName = e.FullName,
                                Address = e.Address,
                                Email = e.Email,
                                DepartmentID = e.DepartmentID,
                                Department = e.Department
                            };*/
            var employees = _dbContext.Employees
            .Join(_dbContext.Departments,
            e => e.DepartmentID,
            d => d.DepartmentID,
            (e, d) => new Employee
            {
                EmployeeID = e.EmployeeID,
                FullName = e.FullName,
                Address = e.Address,
                Email = e.Email,
                DepartmentID = e.DepartmentID,
                Department = e.Department
            }).ToList();
            return employees;
        }

        public Employee GetById(int id)
        {
            //var employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeID == id);
            var employee = (from e in _dbContext.Employees
                            where e.EmployeeID == id
                            select e).FirstOrDefault();
            if (employee == null)
                throw new Exception($"EmployeeID:{id} Not found");
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeWithProject()
        {
            var employees = _dbContext.Employees.Include(e => e.Department).Include(e => e.Projects)
                .ToList();
            return employees;
        }

        public void Update(Employee employee)
        {
            try
            {
                var updateEmployee = GetById(employee.EmployeeID);
                updateEmployee.FullName = employee.FullName;
                updateEmployee.Email = employee.Email;
                updateEmployee.Address = employee.Address;

                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception($"{ex.Message} - {ex.InnerException.Message}");
            }
        }
    }
}