using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee_New> Employee_News { get; set; }
        public DbSet<Department_New> Department_News { get; set; }

        public EmployeeDbContext() : base("EmployeeDbContext")
        {
        }
    }
}