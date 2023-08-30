using MVCTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutorial.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext db = new EmployeeDbContext();
        // GET: New

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult EmployeeList()
        {
            var employeeList = db.Employee_News.ToList();
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EmployeeCreateForm()
        {

            List<Department_New> departments = db.Department_News.ToList();
            ViewBag.DepartmentNames = new SelectList(departments, "DepartmentName", "DepartmentName");

            return View();

        }

        [HttpGet]
        public JsonResult EmployeeEditForm(int employeeid)
        {
            Employee_New employee = db.Employee_News.SingleOrDefault(x => x.EmployeeId == employeeid);

            List<Department_New> list = db.Department_News.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentName", "DepartmentName");

            ViewBag.Employee = employee;
            return Json(employee, JsonRequestBehavior.AllowGet);
        }


        [HttpDelete]
        public JsonResult EmployeeDelete(int employeeId)
        {
            var employee = db.Employee_News.Where(e => e.EmployeeId == employeeId).SingleOrDefault();
            db.Employee_News.Remove(employee);
            db.SaveChanges();
            return Json("Deleted");
        }
    }
}