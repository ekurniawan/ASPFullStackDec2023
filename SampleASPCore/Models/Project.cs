using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string? ProjectName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}