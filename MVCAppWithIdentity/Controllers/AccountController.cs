using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAppWithIdentity.Repository;
using MVCAppWithIdentity.ViewModels;

namespace MVCAppWithIdentity.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountRepository _accountRepository;

        public AccountController(ILogger<AccountController> logger,
        IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _accountRepository.RegisterUser(registerViewModel);
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View();
            }
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var result = await _accountRepository.Login(userViewModel);
                if (result)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ViewData["Error"] = "Login failed! Please check login details and try again.";
                    return View();
                }
            }
            catch (System.Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _accountRepository.Logout();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleCreateViewModel roleCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _accountRepository.AddRole(roleCreateViewModel.RoleName);
                ViewData["Message"] = "Role created successfully!";
                return View();
            }
            catch (System.Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AssignRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AssignRole(AsignRoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _accountRepository.AssignRole(roleViewModel.Username,
                    roleViewModel.RoleName);
                ViewData["Message"] = "Role assigned successfully!";
                return View();
            }
            catch (System.Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}