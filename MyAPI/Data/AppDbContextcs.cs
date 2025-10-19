using Microsoft.EntityFrameworkCore;
using MyAPI.Model;

namespace MyAPI.Data
{
    public class AppDbContextcs : DbContext
    {
        public AppDbContextcs(DbContextOptions<AppDbContextcs> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Department> Departments { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Salary> Salaries { get; set; }
    }
}
