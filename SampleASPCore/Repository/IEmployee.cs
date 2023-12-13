using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;

namespace SampleASPCore.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetEmployeeWithProject();
        Employee GetById(int id);
        Employee Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        void AddEmployeeWithDepartment();
    }
}