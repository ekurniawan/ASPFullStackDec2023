using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SampleASPCore.Models;
using SampleASPCore.Repository;
using SampleASPCore.ViewModels;

namespace SampleASPCore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employees;
        public EmployeesController(IEmployee employees)
        {
            _employees = employees;
        }

        public ActionResult ProcessEF()
        {
            try
            {
                _employees.AddEmployeeWithDepartment();
                return Content("Berhasil proccess");
            }
            catch (System.Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Index()
        {
            string? username = HttpContext.Session.GetString("username");
            //cek session
            if (username.IsNullOrEmpty())
            {
                return LocalRedirect("/Account/Login");
            }
            ViewData["username"] = username;

            if (TempData["Pesan"] != null)
            {
                ViewData["Pesan"] = TempData["Pesan"];
            }
            var listEmployeeViewModel = new List<EmployeeViewModel>();
            var employees = _employees.GetAll();

            foreach (var emp in employees)
            {
                listEmployeeViewModel.Add(new EmployeeViewModel
                {
                    EmployeeID = emp.EmployeeID,
                    FullName = emp.FullName,
                    Email = emp.Email,
                    Address = emp.Address,
                    Department = emp.Department
                });
            }

            return View(listEmployeeViewModel);
            /*ViewData["username"] = "ekurniawan";
            ViewBag.Alamat = "jogja";

            var products = new List<Product>{
                new Product{ProductID=1,ProductName="Product 1"},
                new Product{ProductID=2,ProductName="Product 2"}
            };

            EmployeeWithProductViewModel empWithProductVM = new EmployeeWithProductViewModel
            {
                employees = _employees.GetAll().ToList(),
                products = products
            };*/

            //return new JsonResult(employees);

        }

        public ActionResult GetEmployeeWithProject()
        {
            List<EmployeeWithProjectViewModel> employeeWithProjectViewModels =
                new List<EmployeeWithProjectViewModel>();
            var employees = _employees.GetEmployeeWithProject();
            foreach (var emp in employees)
            {
                var projectViewModels = new List<ProjectViewModel>();
                foreach (var proj in emp.Projects)
                {
                    projectViewModels.Add(new ProjectViewModel
                    {
                        ProjectID = proj.ProjectID,
                        ProjectName = proj.ProjectName
                    });
                }
                employeeWithProjectViewModels.Add(new EmployeeWithProjectViewModel
                {
                    EmployeeID = emp.EmployeeID,
                    FullName = emp.FullName,
                    Email = emp.Email,
                    Address = emp.Address,
                    Department = new DepartmentViewModel
                    {
                        DepartmentID = emp.Department.DepartmentID,
                        DepartmentName = emp.Department.DepartmentName
                    },
                    Projects = projectViewModels
                });
            }

            //return new JsonResult(employeeWithProjectViewModels);
            return View(employeeWithProjectViewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel employeeVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var employee = new Employee
                {
                    FullName = employeeVM.FullName,
                    Email = employeeVM.Email,
                    Address = employeeVM.Address
                };
                var result = _employees.Add(employee);
                TempData["Pesan"] = $"{employee.FullName} berhasil ditambah";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewData["kesalahan"] = $"Gagal tambah data {ex.Message}";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var editEmp = _employees.GetById(id);
            if (editEmp == null)
                return RedirectToAction(nameof(Index));

            var empViewModel = new EditEmployeeViewModel
            {
                EmployeeID = editEmp.EmployeeID,
                FullName = editEmp.FullName,
                Email = editEmp.Email,
                Address = editEmp.Address
            };
            return View(empViewModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(EditEmployeeViewModel editEmployeeVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var editEmployee = new Employee
                {
                    EmployeeID = editEmployeeVM.EmployeeID,
                    FullName = editEmployeeVM.FullName,
                    Email = editEmployeeVM.Email,
                    Address = editEmployeeVM.Address
                };
                _employees.Update(editEmployee);
                TempData["Pesan"] = $"{editEmployee.FullName} berhasil ditambah";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewData["Kesalahan"] = $"Update data employee failed: {ex.Message}";
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var deleteEmp = _employees.GetById(id);
            var model = new EditEmployeeViewModel
            {
                EmployeeID = deleteEmp.EmployeeID,
                FullName = deleteEmp.FullName,
                Email = deleteEmp.Email
            };
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _employees.Delete(id);
                TempData["Pesan"] = $"Data Employee {id} berhasil didelete !";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewData["Kesalahan"] = $"Kesalahan: {ex.Message}";
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