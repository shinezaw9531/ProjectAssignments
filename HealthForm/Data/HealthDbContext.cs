using HealthForm.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthForm.Data
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Health> Health { get; set; }
    }
}
