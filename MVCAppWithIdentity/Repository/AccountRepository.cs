using Microsoft.AspNetCore.Identity;
using MVCAppWithIdentity.ViewModels;

namespace MVCAppWithIdentity.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountRepository(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    //explain method AddRole

    public async Task AddRole(string roleName)
    {
        try
        {
            IdentityResult result;
            var role = new IdentityRole(roleName);
            var isRoleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!isRoleExist)
            {
                result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                    throw new Exception("Role creation failed! Please check role details and try again.");
            }
            else
            {
                throw new Exception("Role already exists!");
            }
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }



    public async Task AssignRole(string userName, string roleName)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.AddToRoleAsync(user, roleName);
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IEnumerable<UserViewModel> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Login(UserViewModel model)
    {
        try
        {
            //var currUser = await _userManager.FindByNameAsync(model.Username);
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (!result.Succeeded)
                throw new Exception("Login failed! Please check login details and try again.");

            return true;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task RegisterUser(RegisterViewModel model)
    {
        try
        {
            var newUser = new IdentityUser()
            {
                UserName = model.Username,
                Email = model.Username
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User creation failed! Please check user details and try again.");
            }
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
