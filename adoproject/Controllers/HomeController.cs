using adoproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace adoproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         EmployeeDataAccess employeeData;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            employeeData = new EmployeeDataAccess();
        }

        public IActionResult Index()
        {
            var r = employeeData.GetEmployees();
            return View(r);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            var r = employeeData.createEmployees(employee);
            if (r)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "error");
                return View(employee);
            }
        }
        public IActionResult Delete(int id)
        {
            var r = employeeData.DeleteEmployees(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var r = employeeData.GetEmployeesbyid(id);
            return View(r);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {

            var r = employeeData.updateEmployees(employee);
            if (r)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "error");
                return View(employee);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
