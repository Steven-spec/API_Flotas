using API_Flotas.Data;
using API_Flotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class SensoresController : ControllerBase
{
    private readonly SensorDbContext _sensorDb;
    private readonly AppDbContext _appDb;
    private readonly AlertaService _alertaService;

    public SensoresController(SensorDbContext sensorDb, AppDbContext appDb, AlertaService alertaService)
    {
        _sensorDb = sensorDb;
        _appDb = appDb;
        _alertaService = alertaService;
    }

    // POST api/sensores/lectura
    [HttpPost("lectura")]
    public async Task<IActionResult> RegistrarLectura([FromBody] SensorLog log)
    {
        if (log == null)
            return BadRequest("El objeto SensorLog es nulo.");

        log.Fecha = DateTime.Now;
        _sensorDb.SensorLogs.Add(log);
        await _sensorDb.SaveChangesAsync();

        // Procesar alerta en background o await si es rápido
        await _alertaService.ProcesarLectura(log);

        return Ok(new { message = "Lectura registrada correctamente." });
    }

    // GET api/sensores/pendientes
    [HttpGet("pendientes")]
    public async Task<IActionResult> GetPendientes()
    {
        var pendientes = await _appDb.Mantenimientos
            .Include(m => m.Camion)
            .Where(m => !m.Realizado && m.Fecha > DateTime.Now)
            .ToListAsync();

        return Ok(pendientes);
    }
}
