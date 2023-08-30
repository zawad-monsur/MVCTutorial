using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models
{
    [Table("Department")] 
    public class Department_New
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
        //[ForeignKey("DepartmentId")]
        public virtual ICollection<Employee_New> Employee_News { get; set; }
    }
}