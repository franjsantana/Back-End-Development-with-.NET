# MyFirstApi

Este es un proyecto introductorio de API Web en .NET utilizando **Controladores** (`Controllers`).

## Descripción

A diferencia de los ejemplos de Minimal API, este proyecto estructura la lógica en Controladores, siguiendo el patrón MVC (Model-View-Controller) común en aplicaciones empresariales más grandes.

La API gestiona una lista simple de productos (cadenas de texto) almacenada en memoria.

## Características

*   **Arquitectura**: Controladores (`[ApiController]`).
*   **Ruta Base**: `/api/products`.
*   **Datos**: Lista estática en memoria (`List<string>`).

## Endpoints

El controlador `ProductsController` expone las siguientes operaciones:

| Método | Endpoint            | Descripción                                      | Cuerpo (Body)           |
| :----- | :------------------ | :----------------------------------------------- | :---------------------- |
| GET    | `/api/products`     | Obtiene la lista completa de productos.          | N/A                     |
| POST   | `/api/products`     | Agrega un nuevo producto a la lista.             | JSON: `"NombreProducto"`|
| PUT    | `/api/products/{id}`| Actualiza un producto existente por su índice.   | JSON: `"NuevoNombre"`   |
| DELETE | `/api/products/{id}`| Elimina un producto por su índice.               | N/A                     |

*Nota: El `{id}` en este ejemplo corresponde al **índice** de la lista (0, 1, 2...), no a un ID de base de datos.*

## Cómo Ejecutar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd MyFirstApi
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```
3.  La API estará escuchando en el puerto configurado (ej. `http://localhost:5000`).

## Ejemplo de Uso

Para agregar un producto (POST):
*   URL: `http://localhost:5000/api/products`
*   Header: `Content-Type: application/json`
*   Body: `"Uvas"`
