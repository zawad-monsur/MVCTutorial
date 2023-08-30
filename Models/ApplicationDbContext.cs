using MVCTutorial.Models;
using System.Data.Entity;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public ApplicationDbContext() : base("MVCTutorialEntities")
    {
    }
}