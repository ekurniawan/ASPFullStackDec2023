using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;

namespace SampleASPCore.Repository
{
    public class InMemoryEmployeeRepository : IEmployee
    {
        private List<Employee> _employees;

        public InMemoryEmployeeRepository()
        {
            _employees = new List<Employee>{
                new Employee{EmployeeID=1,FullName="Erick Kurniawan",Email="erick@gmail.com"},
                new Employee{EmployeeID=2,FullName="Scott Guthrie",Email="scott@gmail.com"},
                new Employee{EmployeeID=3,FullName="Scott Hanselman",Email="hanselman@gmail.com"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeID =
                _employees.OrderByDescending(e => e.EmployeeID).FirstOrDefault().EmployeeID + 1;
            _employees.Add(employee);
            return employee;
        }

        public void AddEmployeeWithDepartment()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            try
            {
                var deleteEmp = GetById(id);
                _employees.Remove(deleteEmp);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }



        public Employee GetById(int id)
        {
            var employee = _employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            if (employee == null)
                throw new Exception($"Employee Id {id} tidak ditemukan");
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeWithProject()
        {
            throw new NotImplementedException();
        }


        public void Update(Employee employee)
        {
            try
            {
                var updateEmp = GetById(employee.EmployeeID);
                updateEmp.FullName = employee.FullName;
                updateEmp.Email = employee.Email;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}