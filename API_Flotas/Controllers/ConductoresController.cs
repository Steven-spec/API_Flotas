using Microsoft.AspNetCore.Mvc;
using API_Flotas.Models;
using Microsoft.EntityFrameworkCore;
using API_Flotas.Data;


[ApiController]
[Route("api/[controller]")]
public class ConductoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public ConductoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Conductor>>> GetConductores()
    {
        return await _context.Conductores.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Conductor>> GetConductor(int id)
    {
        var conductor = await _context.Conductores.FindAsync(id);
        if (conductor == null)
            return NotFound();

        return conductor;
    }

    [HttpPost]
    public async Task<ActionResult<Conductor>> PostConductor(Conductor conductor)
    {
        _context.Conductores.Add(conductor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetConductor), new { id = conductor.Id }, conductor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConductor(int id, Conductor conductor)
    {
        if (id != conductor.Id)
            return BadRequest();

        _context.Entry(conductor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConductor(int id)
    {
        var conductor = await _context.Conductores.FindAsync(id);
        if (conductor == null)
            return NotFound();

        _context.Conductores.Remove(conductor);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
