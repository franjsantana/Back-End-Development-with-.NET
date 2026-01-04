var builder = WebApplication.CreateBuilder(args);

// Añadir servicios para logging, autenticacion y autorizacion
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddAuthentication(); // Configurar autenticacion segun sea necesario
builder.Services.AddAuthorization(); // Configurar autorizacion segun sea necesario
    
var app = builder.Build();

// 1. EXCEPTION HANDLING (siempre primero)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();              // ← Desarrollo
}
else
{
    app.UseExceptionHandler("/Home/Error");       // ← Producción
}

// 2. CUSTOM MIDDLEWARE - Logging de solicitudes y respuestas
app.Use(async(context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}");// PRE-processing 
    await next();// Llamar al siguiente middleware
    Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");// POST-processing  
});

// 3. CUSTOM MIDDLEWARE - Medir tiempo de respuesta
app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;
    Console.WriteLine($"Start Time: {startTime}");// PRE-processing
    await next();// Llamar al siguiente middleware
    var duration = DateTime.UtcNow - startTime; // POST-processing  
    Console.WriteLine($"Response Time: {duration.TotalMilliseconds}ms");
});

app.UseAuthentication(); // Habilitar autenticacion
app.UseAuthorization(); // Habilitar autorizacion
app.UseHttpLogging(); // Habilitar logging HTTP

app.MapGet("/", () => "Hello, ASP.NET Core Middleware!");
app.Run();
