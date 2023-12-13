using MVCAppWithIdentity.ViewModels;

namespace MVCAppWithIdentity.Repository;

public interface IAccountRepository
{
    Task RegisterUser(RegisterViewModel model);
    IEnumerable<UserViewModel> GetAllUsers();
    Task AddRole(string roleName);
    Task AssignRole(string userName, string roleName);
    Task<bool> Login(UserViewModel model);
    Task Logout();
}

