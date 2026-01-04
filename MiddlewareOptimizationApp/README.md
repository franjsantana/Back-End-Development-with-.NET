# MiddlewareOptimizationApp

Este proyecto en ASP.NET Core demuestra cómo implementar un pipeline de **Middleware Optimizado y Seguro**. Se enfoca en el orden correcto de ejecución para maximizar la eficiencia y la seguridad.

## Descripción de la Pipeline

La aplicación configura una serie de middlewares que se ejecutan secuencialmente. El orden es intencional para filtrar solicitudes no deseadas lo antes posible ("Fail Fast").

1.  **Autenticación (Simulada)**:
    *   Verifica si la ruta es `/unauthorized`.
    *   Devuelve `401 Unauthorized` inmediatamente si coincide, evitando procesamiento innecesario.
2.  **Cumplimiento de HTTPS (Simulado)**:
    *   Requiere el parámetro `?secure=true` en la URL.
    *   Devuelve `400 Bad Request` si falta, simulando una redirección o bloqueo de tráfico no seguro.
3.  **Validación de Entrada (Seguridad)**:
    *   Analiza el parámetro `input` para prevenir ataques XSS.
    *   Bloquea cadenas que contengan `<script>` o `javascript:`.
    *   Devuelve `400 Bad Request` si detecta contenido malicioso.
4.  **Autorización y Cookies Seguras**:
    *   Requiere el parámetro `?authenticated=true`.
    *   Si es válido, establece una cookie `SecureCookie` con las banderas `HttpOnly` y `Secure`.
    *   Devuelve `403 Access Denied` si no está autenticado.
5.  **Procesamiento Asíncrono**:
    *   Simula una operación de I/O (`Task.Delay`) para mostrar cómo el pipeline maneja tareas asíncronas sin bloquear el hilo principal.
6.  **Logging de Seguridad (Post-Procesamiento)**:
    *   Este middleware se ejecuta *después* de que los siguientes hayan terminado (gracias al `await next()`).
    *   Monitoriza el código de estado de la respuesta y registra eventos de seguridad en la consola si hay errores (Status Code >= 400).

## Cómo Ejecutar y Probar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd MiddlewareOptimizationApp
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```
    (La app escuchará en `http://localhost:5294` según la configuración).

### Escenarios de Prueba

Para probar el pipeline completo, necesitas ir pasando cada "filtro" secuencialmente.

1.  **Intento Básico (Fallará por HTTPS)**:
    *   URL: `http://localhost:5294/`
    *   Resultado: `400 Bad Request` ("Simulated HTTPS Required").

2.  **Intento con HTTPS, sin Auth (Fallará por Auth)**:
    *   URL: `http://localhost:5294/?secure=true`
    *   Resultado: `403 Access Denied`.

3.  **Intento con HTTPS y Auth (Éxito)**:
    *   URL: `http://localhost:5294/?secure=true&authenticated=true`
    *   Resultado: `200 OK`
        *   "Processed Asynchronously"
        *   "Final Response from Application"
    *   *Nota*: Se establecerá la cookie `SecureCookie`.

4.  **Prueba de Seguridad XSS**:
    *   URL: `http://localhost:5294/?secure=true&authenticated=true&input=<script>alert('xss')</script>`
    *   Resultado: `400 Bad Request` ("Invalid Input").
    *   **Consola**: Verás el log "Security Event..." gracias al middleware de logging.
