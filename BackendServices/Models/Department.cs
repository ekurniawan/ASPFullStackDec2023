namespace BackendServices.Models;

public class Department
{
    public int DepartmentID { get; set; }
    public string? DepartmentName { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
