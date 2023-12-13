using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models
{
    public class Employee
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        public int DepartmentID { get; set; }

        [StringLength(100)]
        [Required]
        public string? FullName { get; set; }

        [StringLength(100)]
        [Required]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public Department? Department { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}