using API_Flotas.Data;
using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



[ApiController]
[Route("api/[controller]")]
public class TalleresController : ControllerBase
{
    private readonly AppDbContext _context;

    public TalleresController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Talleres
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Taller>>> GetTalleres()
    {
        return await _context.Talleres.ToListAsync();
    }

    // GET: api/Talleres/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Taller>> GetTaller(int id)
    {
        var taller = await _context.Talleres.FindAsync(id);
        if (taller == null)
            return NotFound();
        return taller;
    }

    // POST: api/Talleres
    [HttpPost]
    public async Task<ActionResult<Taller>> PostTaller(Taller taller)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Talleres.Add(taller);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTaller), new { id = taller.Id }, taller);
    }

    // PUT: api/Talleres/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTaller(int id, Taller taller)
    {
        if (id != taller.Id)
            return BadRequest();

        _context.Entry(taller).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TallerExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/Talleres/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaller(int id)
    {
        var taller = await _context.Talleres.FindAsync(id);
        if (taller == null)
            return NotFound();

        _context.Talleres.Remove(taller);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TallerExists(int id)
    {
        return _context.Talleres.Any(e => e.Id == id);
    }
}
