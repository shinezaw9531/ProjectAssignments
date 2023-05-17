using Microsoft.EntityFrameworkCore;
using PayloadSystemAPI.Models;

namespace PayloadSystemAPI.Data
{
    public class PayloadAPIDbContext : DbContext
    {
        public PayloadAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DeviceData> DeviceData { get; set; }
    }
}
