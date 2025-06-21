using Microsoft.EntityFrameworkCore;
using API_Flotas.Models;

public class SensorDbContext : DbContext
{
    public SensorDbContext(DbContextOptions<SensorDbContext> options) : base(options) { }

    public DbSet<SensorLog> SensorLogs { get; set; }
}
