using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models
{
    [Table("Employee")]
    public class Employee_New
    {
       //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        //[ForeignKey("Department1")]
        public int DepartmentId { get; set; }

        // public virtual Department_New Department1 { get; set; }
    }
}