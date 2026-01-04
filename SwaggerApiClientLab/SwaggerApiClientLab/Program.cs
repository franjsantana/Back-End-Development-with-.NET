using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyApiClientNamespace;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Paso 2.1 Agrergar servicios necesarios para Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();
       
        // Paso 2.2 Configurar middleware para Swagger
        app.UseSwagger(); // Hace disponible: /swagger/v1/swagger.json
        app.UseSwaggerUI(c => // Hace disponible la interfaz web: /swagger
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });

        // Paso 2.3 Configurar el enrutamiento de controladores
        app.UseRouting();        
        app.MapControllers();

        // 3.1 Ejecutar la generación del cliente
        Console.WriteLine("1. Starting client generation...");

        // 3.2 Ejecutar la API  en segundo plano para que esté disponible el JSON de Swagger
        var apiTask = app.RunAsync();

        // 3.3 Esperar que la API esté lista 
        await Task.Delay(3000); 

        try
        {
            // 3.4 Generar el cliente usando ClientGenerator
            var generator = new ClientGenerator();
            await generator.GenerateClient();
            Console.WriteLine("6. GeneratedApiClient completed successfully.");
        
            // Ultimo paso: Usar el cliente generado
            var httpClient = new HttpClient();
            var client = new GeneratedApiClient("http://localhost:5177", httpClient);
                            
            Console.WriteLine("Calling UserAsync(1)...");
            var user = await client.UserAsync(1); 
            
            Console.WriteLine($"SUCCESS! Fetched User:");
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Name: {user.Name}");     
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Client generation failed: {ex.Message}");
        }
        
        // 3.5 Mantener la API en ejecución
        await apiTask;

        // app.Run();     
    }//Main
}//Program


/* 
Visión general del flujo de trabajo:
TU API (UserController)
     ↓
SWAGGER JSON (/swagger/v1/swagger.json)
     ↓  
NSwag GENERATOR → Cliente C# automático
     ↓
OTRA APLICACIÓN usa el cliente generado
*/


