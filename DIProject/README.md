# Proyecto de Inyección de Dependencias (DI)

Este proyecto es una aplicación web ASP.NET Core que demuestra el concepto de **Inyección de Dependencias** y los diferentes **tiempos de vida (lifetimes)** de los servicios.

## Descripción

La aplicación registra un servicio simple `IMyService` implementado por `MyService`. Este servicio genera un **ID aleatorio** cada vez que se crea una nueva instancia.

A través de middlewares y un endpoint, la aplicación muestra cuándo se crea una nueva instancia del servicio y cuándo se reutiliza una existente, permitiendo visualizar el comportamiento de los diferentes tiempos de vida.

## Estructura del Código

*   **`IMyService.cs`**: Interfaz que define el contrato del servicio.
*   **`MyService.cs`**: Implementación que genera un ID único en su constructor.
*   **`Program.cs`**: Configura el contenedor de servicios y el pipeline de la aplicación.

## Tiempos de Vida (Lifetimes)

En `Program.cs`, puedes descomentar diferentes líneas para probar distintos comportamientos:

1.  **Transient (`AddTransient`)**:
    *   Se crea una **nueva instancia** cada vez que se solicita el servicio.
    *   *Resultado esperado*: Verás un ID diferente en cada log ("First Middleware", "Second Middleware", "Root").

2.  **Scoped (`AddScoped`)** (Configuración actual):
    *   Se crea una instancia **por solicitud HTTP**.
    *   *Resultado esperado*: El ID será el mismo para todos los componentes dentro de la misma petición (mismo ID en middlewares y root), pero cambiará si refrescas la página (nueva petición).

3.  **Singleton (`AddSingleton`)**:
    *   Se crea una **única instancia** para toda la vida de la aplicación.
    *   *Resultado esperado*: El ID será siempre el mismo, sin importar cuántas veces refresques la página o cuántas peticiones hagas.

## Cómo Ejecutar y Probar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd DIProject
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```
3.  Observa la salida en la consola mientras accedes a `http://localhost:5000` (o la URL indicada).

### Ejemplo de Salida (Scoped)
```text
First Middleware - Service ID: 123456
Second Middleware - Service ID: 123456
Root - Service ID: 123456
```
(Al refrescar, cambiará el ID pero se mantendrá constante dentro de esa nueva petición).
