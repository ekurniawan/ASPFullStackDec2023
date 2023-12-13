using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServices.DTO
{
    public class DepartmentCreateDto
    {
        [Required]
        public string? DepartmentName { get; set; }
    }
}