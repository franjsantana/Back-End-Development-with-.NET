# Proyecto de Error Logging

Este proyecto es una API Web en .NET que demuestra las mejores prácticas para el **Manejo de Errores** y **Logging** utilizando la librería **Serilog**.

## Descripción

La aplicación implementa dos estrategias principales para gestionar excepciones y registrar eventos:
1.  **Manejo Global de Errores (System Errors)**: Un middleware captura cualquier excepción no controlada, la registra como un error crítico y devuelve una respuesta genérica al cliente.
2.  **Manejo Específico en Controladores (User Errors)**: El controlador gestiona errores predecibles (como datos de entrada inválidos), los registra como advertencias y devuelve mensajes útiles al cliente.

## Características Técnicas

*   **Logging con Serilog**: Configurado para escribir en:
    *   **Consola**: Para visualización inmediata durante el desarrollo.
    *   **Archivo**: Guarda logs en `logs/myapp.txt`, con rotación diaria.
*   **Middleware Personalizado**: Intercepta excepciones 500 (Internal Server Error).
*   **Controller**: Ejemplo de validación y manejo de `DivideByZeroException`.

## Endpoints

| Método | Ruta | Descripción | Comportamiento de Error |
| :--- | :--- | :--- | :--- |
| GET | `/api/ErrorHandling/division` | Realiza una división. | Devuelve 400 si el denominador es 0 (Warning). Errores inesperados devuelven 500 (Error). |

## Cómo Ejecutar y Probar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd Error_Logging
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```

### Casos de Prueba

1.  **División Válida**:
    *   Navega a: `/api/ErrorHandling/division?numerador=10&denominador=2`
    *   Resultado: `200 OK`, cuerpo `5`.

2.  **Error de Usuario (Warning)**:
    *   Navega a: `/api/ErrorHandling/division?numerador=10&denominador=0`
    *   Resultado: `400 Bad Request`, mensaje "No se puede dividir por cero.".
    *   **Log**: Se registra un `Warning` en la consola y archivo.

3.  **Error de Sistema (Error)**:
    *   (Para probar esto, podrías modificar el código para lanzar una excepción no controlada).
    *   Resultado: `500 Internal Server Error`, mensaje "Se produjo un error inesperado...".
    *   **Log**: Se registra un `Error` con el stack trace completo.
