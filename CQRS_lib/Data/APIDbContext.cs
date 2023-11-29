using Microsoft.EntityFrameworkCore;
using CQRS_lib.Data.Config;
using CQRS_lib.Models;

namespace CQRS_lib.Data
{
    public class APIDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public APIDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfigurations).Assembly);
        }
    }
}
