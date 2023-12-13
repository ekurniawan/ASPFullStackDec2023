using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCAppWithIdentity.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Admin,HRD")]
        public IActionResult Index()
        {
            
            return View();
        }

        [Authorize(Roles = "Admin,Finance")]
        public IActionResult About()
        {
            return View();
        }

        
    }
}