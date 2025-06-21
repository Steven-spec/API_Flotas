using API_Flotas.Models;
using Microsoft.EntityFrameworkCore;
using API_Flotas.Data;


public class AlertaService
{
    private readonly AppDbContext _appDb;
    private readonly SensorDbContext _sensorDb;

    public AlertaService(AppDbContext appDb, SensorDbContext sensorDb)
    {
        _appDb = appDb;
        _sensorDb = sensorDb;
    }

    public async Task ProcesarLectura(SensorLog log)
    {
        var camion = await _appDb.Camiones.FindAsync(log.CamionId);
        if (camion == null) return;

        camion.KilometrajeActual = log.Kilometraje;
        await _appDb.SaveChangesAsync();

        // Reglas simples de mantenimiento predictivo
        if (log.Kilometraje % 10000 == 0)
        {
            var alerta = new AlertaMantenimiento
            {
                CamionId = camion.Id,
                Mensaje = $"El camión {camion.Placa} necesita revisión por superar los {log.Kilometraje} km.",
                FechaGenerada = DateTime.Now
            };

            // Aquí podrías guardar en una tabla de alertas o enviar notificación externa
            Console.WriteLine($"[ALERTA]: {alerta.Mensaje}");

            // O incluso crear un mantenimiento automáticamente
            var mantenimiento = new Mantenimiento
            {
                CamionId = camion.Id,
                Fecha = DateTime.Now.AddDays(5),
                Tipo = "Preventivo",
                TallerId = _appDb.Talleres.First().Id,
                Realizado = false
            };

            _appDb.Mantenimientos.Add(mantenimiento);
            await _appDb.SaveChangesAsync();
        }
    }
}
