# MiddlewareApp

Este proyecto es una aplicación web ASP.NET Core que ilustra cómo funciona el pipeline de **Middleware** y cómo crear middlewares personalizados.

## Descripción

El código (`Program.cs`) configura una tubería de procesamiento de solicitudes HTTP donde cada middleware tiene la oportunidad de actuar antes y después del siguiente componente.

## Middlewares Implementados

El orden de los middlewares es crítico y se configura de la siguiente manera:

1.  **Manejo de Excepciones**:
    *   `UseDeveloperExceptionPage`: En entorno de desarrollo.
    *   `UseExceptionHandler`: En entorno de producción.
2.  **Middleware Personalizado 1 (Logging)**:
    *   **Pre-procesamiento**: Imprime la ruta de la solicitud (`Request Path`).
    *   **Post-procesamiento**: Imprime el código de estado de la respuesta (`Response Status Code`).
3.  **Middleware Personalizado 2 (Performance)**:
    *   **Pre-procesamiento**: Registra la hora de inicio.
    *   **Post-procesamiento**: Calcula e imprime el tiempo total que tomó procesar la solicitud (`Response Time`).
4.  **Autenticación y Autorización**: `UseAuthentication` y `UseAuthorization`.
5.  **HTTP Logging**: `UseHttpLogging` para registros detallados.
6.  **Endpoint Final**: `app.MapGet("/", ...)` devuelve un mensaje de bienvenida.

## Cómo Ejecutar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd MiddlewareApp
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```
3.  Abre un navegador y ve a `http://localhost:5000` (o la URL indicada).

## Observando el Flujo

Revisa la **consola** donde ejecutas la aplicación. Verás los logs generados por los middlewares personalizados en el orden de ejecución:

```text
Request Path: /
Start Time: [Fecha y Hora]
(Se procesa el endpoint)
Response Time: X ms
Response Status Code: 200
```

Esto demuestra cómo la solicitud "baja" por el pipeline y la respuesta "sube" de vuelta.
