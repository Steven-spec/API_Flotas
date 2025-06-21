using API_Flotas.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registro de contexto para SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

// Si tienes otro contexto para MariaDB (ejemplo: SensorDbContext)
builder.Services.AddDbContext<SensorDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MariaDbConnection"),
        new MySqlServerVersion(new Version(10, 4, 27)))); // Cambia versión según MariaDB

// Otros servicios e inyección
builder.Services.AddScoped<MantenimientoService>();
builder.Services.AddScoped<AlertaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
