using System.ComponentModel.DataAnnotations;

namespace MVCAppWithIdentity.ViewModels;

public class RoleCreateViewModel
{
    [Required]
    public string RoleName { get; set; }
}
