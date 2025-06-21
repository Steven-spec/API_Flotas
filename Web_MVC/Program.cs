using Api_Flotas.Consumer;
using API_Flotas.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar endpoints para la clase Crud<T>
Crud<Camion>.EndPoint = "https://localhost:7235/api/Camiones";
Crud<Conductor>.EndPoint = "https://localhost:7235/api/Conductores";
Crud<Taller>.EndPoint = "https://localhost:7235/api/Talleres";
Crud<Mantenimiento>.EndPoint = "https://localhost:7235/api/Mantenimientos";
Crud<AlertaMantenimiento>.EndPoint = "https://localhost:7235/api/Alertas";

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
