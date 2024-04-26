using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Employee> AllEmployees { get; set; }

        public DbSet <Leaves> AllLeaves { get; set; }
        public DbSet<LoginDetails> AllLoginDetails { get; set; }
    }
}
