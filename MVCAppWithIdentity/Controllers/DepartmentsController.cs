using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAppWithIdentity.Services;

namespace MVCAppWithIdentity.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentServices _departmentServices;

        public DepartmentsController(ILogger<DepartmentsController> logger,
        IDepartmentServices departmentServices)
        {
            _logger = logger;
            _departmentServices = departmentServices;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _departmentServices.GetAll();
            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}