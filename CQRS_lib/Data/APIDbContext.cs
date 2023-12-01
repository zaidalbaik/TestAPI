using Microsoft.EntityFrameworkCore;
using CQRS_lib.Data.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CQRS_lib.Data.Models;

namespace CQRS_lib.Data
{
    public class APIDbContext : IdentityDbContext<AppUser>
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
