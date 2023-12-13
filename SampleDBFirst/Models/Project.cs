using System;
using System.Collections.Generic;

namespace SampleDBFirst.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public virtual ICollection<Employee> EmployeesEmployees { get; set; } = new List<Employee>();
}
