using System.ComponentModel.DataAnnotations;

namespace SampleASPCore.ViewModels;

public class EditEmployeeViewModel
{
    public int EmployeeID { get; set; }

    [Required(ErrorMessage = "Fullname tidak boleh kosong")]
    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }
}
