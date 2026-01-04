using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;
public class ClientGenerator
{
    public async Task GenerateClient()
    {
        using var httpClient = new HttpClient();
        
        try 
        {
        // 1. Obtener el JSON de Swagger desde la URL proporcionada
        var swaggerJson = await httpClient.GetStringAsync("http://localhost:5177/swagger/v1/swagger.json");
        Console.WriteLine("2. Swagger JSON downloaded successfully");
        
        // 2. Parsear el documento OpenAPI
        var document = await OpenApiDocument.FromJsonAsync(swaggerJson);
        Console.WriteLine("3. OpenAPI document parsed");

        // 3. Configurar el generador de cliente C#
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "GeneratedApiClient",
            CSharpGeneratorSettings = { Namespace = "MyApiClientNamespace" }
        };
        
        // 4. Generar el código del cliente C#
        var generator = new CSharpClientGenerator(document, settings);
        var code = generator.GenerateFile();
        Console.WriteLine("4. Client code generated");

        // 5. Guardar el código generado en un archivo .cs
        await File.WriteAllTextAsync("GeneratedApiClient.cs", code);
        Console.WriteLine("5. 💾 File saved: GeneratedApiClient.cs");

        }   
        catch (Exception ex)
        {
            Console.WriteLine($"Error al generar el cliente: {ex.Message}");
        }
    }//GenerateClient
}//ClientGenerator

/*
 En este paso usarás NSwag para generar código cliente a partir de la documentación de Swagger, 
 lo que permitirá que el código del lado del cliente interactúe automáticamente con los puntos finales del servidor.
*/