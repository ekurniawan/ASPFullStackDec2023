using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleDBFirst.Repository;

namespace SampleDBFirst.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartment _department;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(ILogger<DepartmentsController> logger, IDepartment department)
        {
            _department = department;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var departments = _department.GetAll();
            try
            {
                _department.Delete(9);
                return new JsonResult(departments);
            }
            catch (System.Exception ex)
            {
                return Content(ex.Message);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}