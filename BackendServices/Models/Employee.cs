using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServices.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;
        
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
    }
}