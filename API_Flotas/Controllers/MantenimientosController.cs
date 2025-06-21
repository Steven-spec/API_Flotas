using API_Flotas.Data;
using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class MantenimientosController : ControllerBase
{
    private readonly AppDbContext _context;

    public MantenimientosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Mantenimientos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetMantenimientos()
    {
        return await _context.Mantenimientos
            .Include(m => m.Camion)
            .Include(m => m.Taller)
            .ToListAsync();
    }

    // GET: api/Mantenimientos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Mantenimiento>> GetMantenimiento(int id)
    {
        var mantenimiento = await _context.Mantenimientos
            .Include(m => m.Camion)
            .Include(m => m.Taller)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (mantenimiento == null)
            return NotFound();

        return mantenimiento;
    }

    // POST: api/Mantenimientos
    [HttpPost]
    public async Task<ActionResult<Mantenimiento>> PostMantenimiento(Mantenimiento mantenimiento)
    {
        _context.Mantenimientos.Add(mantenimiento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMantenimiento), new { id = mantenimiento.Id }, mantenimiento);
    }

    // PUT: api/Mantenimientos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMantenimiento(int id, Mantenimiento mantenimiento)
    {
        if (id != mantenimiento.Id)
            return BadRequest("El ID no coincide.");

        _context.Entry(mantenimiento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MantenimientoExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/Mantenimientos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMantenimiento(int id)
    {
        var mantenimiento = await _context.Mantenimientos.FindAsync(id);
        if (mantenimiento == null)
            return NotFound();

        _context.Mantenimientos.Remove(mantenimiento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MantenimientoExists(int id)
    {
        return _context.Mantenimientos.Any(e => e.Id == id);
    }
}
