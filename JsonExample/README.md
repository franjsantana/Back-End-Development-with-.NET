# Proyecto JsonExample

Este es una aplicación de consola en .NET que demuestra cómo trabajar con JSON utilizando la popular librería **Newtonsoft.Json** (también conocida como Json.NET).

## Descripción

El proyecto muestra ejemplos básicos de:
1.  **Deserialización**: Convertir una cadena de texto en formato JSON a un objeto C# (`Person`).
2.  **Serialización** (comentado en el código): Convertir un objeto C# a una cadena JSON.

La clase `Person` utilizada tiene la siguiente estructura:
```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

## Dependencias

Este proyecto utiliza el paquete NuGet:
*   `Newtonsoft.Json`

## Cómo Ejecutar

1.  Asegúrate de tener el SDK de .NET instalado.
2.  Navega a la carpeta del proyecto:
    ```bash
    cd JsonExample
    ```
3.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```

## Salida Esperada

Al ejecutar el programa, verás el resultado de la deserialización de la cadena `{"Name":"Alice","Age":30}`:

```text
Name: Alice, Age: 30
```

*Nota: En `Program.cs` hay un bloque de código comentado que muestra cómo realizar la operación inversa (Serialización).*
