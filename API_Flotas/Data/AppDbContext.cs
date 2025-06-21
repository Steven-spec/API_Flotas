using API_Flotas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Flotas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Camion> Camiones { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
    }
}
