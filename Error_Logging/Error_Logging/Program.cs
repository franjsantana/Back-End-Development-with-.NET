using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Configura Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() //Logging en consola
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day) //Logging en archivo
    .CreateLogger();

builder.Host.UseSerilog();//Integra Serilog con el host de la aplicación    

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

//Configura middleware de manejo de errores global
app.Use(async (context, next) =>
{
    try
    {
        await next();//Ejecuta el siguiente middleware/controller
    }

    catch (Exception ex)
    {
        Log.Error(ex, "Error capturado...");  // ← Error
        context.Response.StatusCode = 500;//Código de estado para error interno del servidor
        await context.Response.WriteAsync("Se produjo un error inesperado. Por favor, inténtalo de nuevo más tarde.");
    }
});

// Habilita el enrutamiento y los controladores
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

/*
Para errores DEL SISTEMA (como BD caída):
- Middleware global los captura
- Status 500 + mensaje genérico
- Log como Error (sí es error del sistema)
*/
