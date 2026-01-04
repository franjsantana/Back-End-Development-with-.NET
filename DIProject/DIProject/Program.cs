using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<IMyService, MyService>(); //Singleton lifetime
builder.Services.AddScoped<IMyService, MyService>(); //Scoped lifetime
//builder.Services.AddTransient<IMyService, MyService>(); //Transient lifetime


var app = builder.Build();

app.Use(async (context, next) =>//Middleware 1
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();//Obtener la instancia del servicio
    myService.LogCreation("First Middleware");//Registrar la creacion del servicio
    await next();//Llamar al siguiente middleware
});

app.Use(async (context, next) =>//Middleware 2
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Second Middleware");
    await next();
});

app.MapGet("/", (IMyService myService) =>//Fin de la ruta
{
    myService.LogCreation("Root");
    return Results.Ok("Check the console for service ID logs.");
});

app.Run();




