using MVCTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutorial.Controllers
{
    public class Employee_NewController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();
        // GET: Employee_New
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            var employees = db.Employee_News.ToList();

            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDepartmentNames()
        {
            var departments = db.Department_News.Select(d => new
            {
                Value = d.DepartmentId,
                Text = d.DepartmentName
            }).ToList();

            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetEmployeeDetails(int employeeId)
        {
            var employee = db.Employee_News.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee_New employee)
        {
            var existingEmployee = db.Employee_News.Find(employee.EmployeeId);
            if (existingEmployee == null)
            {
                return HttpNotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.DepartmentId = employee.DepartmentId;

            db.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int employeeId)
        {
            var employee = db.Employee_News.Find(employeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }

            db.Employee_News.Remove(employee);
            db.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult CreateEmployee(int Id, string Name, int DepartmentId)
        {
            Department_New dpt = db.Department_News.SingleOrDefault(x => x.DepartmentId == DepartmentId);

            var newEmployee = new Employee_New
            {
                EmployeeId = Id,
                Name = Name,
                DepartmentId = DepartmentId,
                Department = dpt.DepartmentName
            };

            Employee_New employee = new Employee_New();
            employee.Name = Name;
            employee.EmployeeId = Id;
            employee.Department = dpt.DepartmentName;
            employee.DepartmentId = DepartmentId;

            db.Employee_News.Add(employee);
            db.SaveChanges();

            //db.Employee_News.Add(newEmployee);
            //db.SaveChanges();

            return Json(new { success = true });
        }
    }
}

