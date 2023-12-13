using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendServices.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendServices.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Employee> Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesWithDepartments()
        {
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();
            return employees;
        }

        public Task<Employee> Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}