using Demo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Department> Departments { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
