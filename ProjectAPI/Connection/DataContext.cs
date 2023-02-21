using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.Connection
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        DbSet<CAR> CAR { get; set; }
    }
}
