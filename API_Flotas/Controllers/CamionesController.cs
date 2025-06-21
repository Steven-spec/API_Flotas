using API_Flotas.Data;
using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class CamionesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CamionesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Camiones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Camion>>> GetCamiones()
    {
        return await _context.Camiones.ToListAsync();
    }

    // GET: api/Camiones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Camion>> GetCamion(int id)
    {
        var camion = await _context.Camiones.FindAsync(id);

        if (camion == null)
        {
            return NotFound();
        }

        return camion;
    }

    // POST: api/Camiones
    [HttpPost]
    public async Task<ActionResult<Camion>> PostCamion(Camion camion)
    {
        _context.Camiones.Add(camion);
        await _context.SaveChangesAsync();

        // Retorna la URI para obtener el nuevo recurso creado
        return CreatedAtAction(nameof(GetCamion), new { id = camion.Id }, camion);
    }

    // PUT: api/Camiones/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCamion(int id, Camion camion)
    {
        if (id != camion.Id)
        {
            return BadRequest("El ID del camión no coincide con el ID de la URL.");
        }

        _context.Entry(camion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CamionExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Camiones/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCamion(int id)
    {
        var camion = await _context.Camiones.FindAsync(id);
        if (camion == null)
        {
            return NotFound();
        }

        _context.Camiones.Remove(camion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CamionExists(int id)
    {
        return _context.Camiones.Any(e => e.Id == id);
    }
}
