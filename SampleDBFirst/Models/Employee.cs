using System;
using System.Collections.Generic;

namespace SampleDBFirst.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Project> ProjectsProjects { get; set; } = new List<Project>();
}
