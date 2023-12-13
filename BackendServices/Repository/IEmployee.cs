using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendServices.Models;

namespace BackendServices.Repository
{
    public interface IEmployee : ICrud<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesWithDepartments();
    }
}