var builder = WebApplication.CreateBuilder(args);

// Configura para escuchar en HTTP por simplicidad
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5294); // HTTP port
});

var app = builder.Build();

// 1. Middleware para manejar autenticación (primero - seguridad)
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/unauthorized")
    {
        if (!context.Response.HasStarted) //Evita escribir multiples veces en la respuesta
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized Access");
        }
        return; // Exit middleware pipeline early if unauthorized
    }
    await next();
});

// 2. Middleware para simular la aplicación de HTTPS
app.Use(async (context, next) =>
{
    // Check for a query parameter to simulate HTTPS enforcement (e.g., "?secure=true")
    if (context.Request.Query["secure"] != "true")
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Simulated HTTPS Required");
        return;
    }

    await next();
});

// 3. Middleware para validar entradas y prevenir XSS como <script> o javascript
app.Use(async (context, next) =>
{
    var input = context.Request.Query["input"].ToString();
    
    if (!IsValidInput(input))
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid Input");
        }
        return;
    }

    await next();
});

// 4. Middleware para manejar autorización y establecer cookies seguras
app.Use(async (context, next) =>
{
    // Simulate authentication with a query parameter (e.g., "?authenticated=true")
    var isAuthenticated = context.Request.Query["authenticated"] == "true";
    if (!isAuthenticated)
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Access Denied");
        }
        return;
    }

    context.Response.Cookies.Append("SecureCookie", "SecureData", new CookieOptions
    {
        HttpOnly = true, // Previene acceso via JavaScript (protección XSS)
        Secure = true // Solo se envía sobre HTTPS (en producción)
    });

    await next();
});

// 5. Middleware para manejar solicitudes asíncronas
app.Use(async (context, next) =>
{
    await Task.Delay(100); // Simulate async operation
    if (!context.Response.HasStarted)
    {
        await context.Response.WriteAsync("Processed Asynchronously\n");
    }
    await next();
});

// 6. Middleware para registrar eventos de seguridad después de que se haya procesado la respuesta
app.Use(async (context, next) =>
{
    await next(); // Run the next middleware first

    if (context.Response.StatusCode >= 400)
    {
        Console.WriteLine($"Security Event: {context.Request.Path} - Status Code: {context.Response.StatusCode}");
    }
});

// Función para validar entradas
static bool IsValidInput(string input)
{
     // Permitir null/empty
    if (string.IsNullOrEmpty(input))
        return true;
        
    // Solo bloquear contenido claramente malicioso
    return !input.Contains("<script>", StringComparison.OrdinalIgnoreCase) &&
           !input.Contains("javascript:", StringComparison.OrdinalIgnoreCase);
}

// Final Response Middleware
app.Run(async (context) =>
{
    if (!context.Response.HasStarted)
    {
        await context.Response.WriteAsync("Final Response from Application\n");
    }
});

app.Run();








