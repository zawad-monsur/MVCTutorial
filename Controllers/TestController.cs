using MVCTutorial.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutorial.Controllers
//{
//    public class TestController : Controller
//    {
//     //   private ApplicationDbContext db = new ApplicationDbContext();
//        // GET: Test
//        public ActionResult Index()
//        {
//            //Hard coded data
//            //List<Employee> employeeList = new List<Employee>();
//            //Employee employee = new Employee();

//            //employeeList.Add(new Employee { EmployeeID = 1, Name = "Sam", Department = "IT" });
//            //employeeList.Add(new Employee { EmployeeID = 2, Name = "Sam2", Department = "IT2" });
//            //employeeList.Add(new Employee { EmployeeID = 3, Name = "Sam3", Department = "IT3" });

//            //ViewBag.EmployeeList = employeeList;
//            //ViewData["EmployeeList"] = employeeList;

//            //ViewBag.EmployeeNameVB = "Marry";
//            //ViewData["EmployeeNameVD"] = "Ashish";
//            //TempData["EmployeeTD"] = "John";

//            MVCTutorialEntities db = new MVCTutorialEntities();

//            //List<Employee> employeeList = db.Employees.ToList();

//            //EmployeeViewModel employeeVM = new EmployeeViewModel();

//            //List<EmployeeViewModel> employeeVMList = employeeList.Select(x => new EmployeeViewModel
//            //{
//            //    Name = x.Name,
//            //    EmployeeId = x.EmployeeId,
//            //    DepartmentId = x.DepartmentId,
//            //    DepartmentName = x.Department1.DepartmentName
//            //}).ToList();

//        }
//    }
//}


{

    public class TestController : Controller
    {
        MVCTutorialEntities db = new MVCTutorialEntities();
        // GET: Test
        public ActionResult Index()
        {

            MVCTutorialEntities db = new MVCTutorialEntities();
            List<Employee> employee = db.Employees.ToList();

            return View(employee);

        }

        public ActionResult AllEmployees()
        {
            MVCTutorialEntities db = new MVCTutorialEntities();
            List<Employee> employee = db.Employees.ToList();

            return View(employee);
        }

        public ActionResult EmployeeDetail(int EmployeeId)
        {
            MVCTutorialEntities db = new MVCTutorialEntities();
            Employee employee = db.Employees.SingleOrDefault(x => x.EmployeeId == EmployeeId);

            ViewBag.Employee = employee;
            return View(employee);
        }

        public ActionResult DisplayData()
        {
            MVCTutorialEntities db = new MVCTutorialEntities();
            List<Employee> employees = db.Employees.ToList();
            List<Department> departments = db.Departments.ToList();

            ViewBag.Departments = departments;
            ViewBag.Employees = employees;

            return View();
        }

        public ActionResult SaveForm()
        {
            MVCTutorialEntities db = new MVCTutorialEntities();
            List<Department> list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentName", "DepartmentName");

            return View();
        }

        [HttpPost]
        public ActionResult SaveRecord(Employee model)
        {
            MVCTutorialEntities db = new MVCTutorialEntities();
            try
            {
                Department dpt = db.Departments.SingleOrDefault(x => x.DepartmentName == model.Department);

                Employee employee = new Employee();
                employee.Name = model.Name;
                employee.EmployeeId = model.EmployeeId;
                employee.Department = model.Department;
                employee.DepartmentId = dpt.DepartmentId;

                db.Employees.Add(employee);
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            db.Employees.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Employee Added Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int EmployeeId)
        {
            MVCTutorialEntities db = new MVCTutorialEntities();
            Employee employee = db.Employees.SingleOrDefault(x => x.EmployeeId == EmployeeId);

            List<Department> list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentName", "DepartmentName");

            ViewBag.Employee = employee;
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmp(Employee model)
        {
            try
            {
                Employee employee = db.Employees.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
                Department dpt = db.Departments.SingleOrDefault(x => x.DepartmentName == model.Department);
                if (employee != null)
                {
                    employee.EmployeeId = model.EmployeeId;
                    employee.Name = model.Name;
                    employee.Department = model.Department;
                    employee.DepartmentId = dpt.DepartmentId;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int EmployeeId)
        {
            var employee = db.Employees.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
            ViewBag.Message = "Employee Deleted";
            return RedirectToAction("Index");
        }


    }
}