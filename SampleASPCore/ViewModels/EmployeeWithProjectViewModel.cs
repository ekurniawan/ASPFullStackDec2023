using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;

namespace SampleASPCore.ViewModels
{
    public class EmployeeWithProjectViewModel
    {

        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [StringLength(100)]
        [Required]
        public string? FullName { get; set; }

        [StringLength(100)]
        [Required]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public DepartmentViewModel Department { get; set; }

        public ICollection<ProjectViewModel>? Projects { get; set; }

    }
}