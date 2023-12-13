using System.ComponentModel.DataAnnotations;

namespace MVCAppWithIdentity.ViewModels;

public class AsignRoleViewModel
{
    [Required]
    public string RoleName { get; set; }

    [Required]
    public string Username { get; set; }
}
