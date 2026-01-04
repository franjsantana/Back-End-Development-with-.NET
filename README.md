# Back-End Development with .NET 🚀

Este repositorio contiene una colección de proyectos y laboratorios prácticos diseñados para aprender y dominar el desarrollo Back-End moderno con **.NET 8/9** y **C#**.

Desde conceptos fundamentales como la serialización y la inyección de dependencias, hasta la creación de APIs RESTful robustas y seguras.

## 📂 Contenido del Repositorio

A continuación se describe cada uno de los proyectos incluidos:

### Fundamentos de .NET

*   **`Serialization`**: Ejemplos de persistencia de datos usando serialización **Binaria**, **XML** y **JSON**.
*   **`Deserialization`**: Cómo reconstruir objetos a partir de formatos binarios, XML y JSON.
*   **`SerializationSecurity`**: Prácticas de seguridad cruciales en la serialización (encriptación de datos sensibles, integridad con hashing, validación de fuentes).
*   **`JsonExample`**: Uso específico de la librería `Newtonsoft.Json` para manipular datos JSON.
*   **`DIProject`**: Demostración interactiva de **Inyección de Dependencias** y los tiempos de vida de los servicios (Transient, Scoped, Singleton).

### Desarrollo de APIs Web

*   **`MyFirstApi`**: Introducción a las APIs Web utilizando el patrón clásico de **Controladores** (MVC).
*   **`Api_Example`**: API rápida y ligera utilizando **Minimal APIs**, ideal para microservicios.
*   **`UserManagementAPI`**: Proyecto completo de referencia. API RESTful con Autenticación **JWT**, Swagger, Logging avanzado y mejores prácticas.
*   **`SwaggerApiClientLab`**: Automatización avanzada que muestra cómo generar un **cliente C#** automáticamente a partir de una especificación Swagger.

### Middleware y Pipeline

*   **`MiddlewareApp`**: Comprensión del pipeline de solicitudes HTTP. Creación de middlewares personalizados para logging y métricas.
*   **`MiddlewareOptimizationApp`**: Implementación de un pipeline optimizado y seguro (Autenticación, HTTPS, Validación de entradas contra XSS).

### Observabilidad y Errores

*   **`Error_Logging`**: Estrategias profesionales para el manejo de excepciones (global vs local) y logging estructurado con **Serilog** (Consola y Archivo).

## 🚀 Cómo Empezar

Cada carpeta contiene su propio proyecto independiente. Para ejecutar cualquiera de ellos:

1.  Asegúrate de tener instalado el [**.NET SDK**](https://dotnet.microsoft.com/download).
2.  Navega a la carpeta del proyecto deseado:
    ```bash
    cd NombreDelProyecto
    ```
3.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```
4.  Consulta el archivo `README.md` dentro de cada subdirectorio para detalles específicos.

## 📝 Licencia

Este material es para fines educativos.
