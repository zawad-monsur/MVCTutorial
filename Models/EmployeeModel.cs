using MVCTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        //public string Department { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        //public string Department1 { get; set; }
    }
}