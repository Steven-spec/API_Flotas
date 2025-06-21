using API_Flotas.Models;
using Microsoft.EntityFrameworkCore;
using API_Flotas.Data;


public class MantenimientoService
{
    private readonly AppDbContext _context;

    public MantenimientoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Mantenimiento>> ObtenerMantenimientosPendientes()
    {
        return await _context.Mantenimientos
            .Include(m => m.Camion)
            .Include(m => m.Taller)
            .Where(m => !m.Realizado && m.Fecha > DateTime.Now)
            .ToListAsync();
    }
}
