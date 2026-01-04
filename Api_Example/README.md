# Api_Example

Este es un proyecto simple de API Web construido con .NET utilizando **Minimal APIs**. Demuestra operaciones CRUD básicas sobre una lista en memoria de "Items".

## Características

*   **Tecnología**: .NET Core / .NET (Minimal API).
*   **Datos**: Almacenamiento en memoria (volátil), se reinicia al detener la aplicación.
*   **Funcionalidad**: Gestión completa (Crear, Leer, Actualizar, Borrar) de elementos.

## Endpoints de la API

La API expone los siguientes endpoints HTTP:

| Método | Endpoint       | Descripción                                      | Cuerpo (Body)           |
| :----- | :------------- | :----------------------------------------------- | :---------------------- |
| GET    | `/`            | Mensaje de bienvenida.                           | N/A                     |
| GET    | `/items`       | Obtiene la lista de todos los items.             | N/A                     |
| GET    | `/items/{id}`  | Obtiene un item específico por su ID.            | N/A                     |
| POST   | `/items`       | Crea un nuevo item.                              | JSON: `{ "name": "..." }` |
| PUT    | `/items/{id}`  | Actualiza un item existente.                     | JSON: `{ "name": "..." }` |
| DELETE | `/items/{id}`  | Elimina un item por su ID.                       | N/A                     |

## Cómo Ejecutar

1.  Asegúrate de tener el SDK de .NET instalado.
2.  Navega a la carpeta del proyecto:
    ```bash
    cd Api_Example
    ```
3.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```
4.  La API estará disponible (por defecto) en `http://localhost:5000` o la URL que indique la consola.

## Estructura del Proyecto

*   `Program.cs`: Contiene toda la lógica de la aplicación y la definición de endpoints.
*   `Models/Item.cs`: Definición de la clase `Item`.
