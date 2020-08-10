using EmployeeRegister.Core.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegister.Core.Models
{
    public class EmployeeRegisterDatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeRegisterDatabaseContext(DbContextOptions<EmployeeRegisterDatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
