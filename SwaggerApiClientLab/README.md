# SwaggerApiClientLab

Este proyecto demuestra un flujo de trabajo avanzado de automatización: **Generación de un Cliente API (C#)** a partir de una especificación Swagger/OpenAPI en tiempo de ejecución.

## Descripción del Flujo

El código en `Program.cs` orquesta los siguientes pasos automáticamente:

1.  **Inicia la API**: Arranca la aplicación web que expone endpoints y la documentación Swagger (`/swagger/v1/swagger.json`).
2.  **Generación de Cliente**:
    *   Utiliza una herramienta (en este caso una clase `ClientGenerator`) para leer el JSON de Swagger expuesto por la propia API.
    *   Genera automáticamente el código fuente de un cliente C# (`GeneratedApiClient.cs`) utilizando **NSwag**.
3.  **Consumo**:
    *   Compila y utiliza inmediatamente el cliente generado (`GeneratedApiClient`) para realizar peticiones HTTP a la API.

## Componentes Clave

*   **`Program.cs`**: El punto de entrada que coordina todo el proceso (ejecutar API, esperar, generar cliente, usar cliente).
*   **`GeneratedApiClient.cs`**: El archivo que contiene el código del cliente generado automáticamente por NSwag. **No se debe editar manualmente**, ya que se sobrescribe.
*   **NSwag**: La librería y herramienta utilizada para la generación de código.

## Cómo Ejecutar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd SwaggerApiClientLab
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```

## Salida Esperada en Consola

Verás una secuencia de logs indicando el progreso:

```text
1. Starting client generation...
...
6. GeneratedApiClient completed successfully.
Calling UserAsync(1)...
SUCCESS! Fetched User:
ID: 1
Name: [Nombre del usuario]
```

Este laboratorio es ideal para entender cómo mantener sincronizados el backend y los clientes (frontend o SDKs) automáticamente.
