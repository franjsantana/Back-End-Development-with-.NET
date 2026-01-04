# Proyecto de Deserialización

Este proyecto es una aplicación de consola en .NET que demuestra y compara diferentes métodos de deserialización de datos: **Binaria**, **XML** y **JSON**.

## Descripción

El objetivo es mostrar cómo convertir datos en diferentes formatos (binario, XML, JSON) de vuelta a objetos C# (`Person`). Además, mide el tiempo que toma cada proceso de deserialización para fines comparativos.

La clase principal `Person` tiene la siguiente estructura:
```csharp
public class Person
{
    public string UserName { get; set; }
    public int UserAge { get; set; }
}
```

## Métodos de Deserialización Mostrados

1.  **Deserialización Binaria**:
    *   Lee datos desde un archivo binario generado (`person.dat`).
    *   Usa `System.IO.BinaryReader` para leer tipos primitivos secuencialmente.
    *   *Nota*: Muestra cómo reconstruir un objeto manualmente leyendo bytes.

2.  **Deserialización XML**:
    *   Utiliza `System.Xml.Serialization.XmlSerializer`.
    *   Deserializa una cadena XML cruda: `<Person><UserName>Bob</UserName><UserAge>30</UserAge></Person>`.

3.  **Deserialización JSON**:
    *   Utiliza `System.Text.Json.JsonSerializer`.
    *   Deserializa una cadena JSON cruda: `{"UserName":"Charlie","UserAge":28}`.
    *   Es el método más común en aplicaciones web modernas.

## Cómo Ejecutar

1.  Asegúrate de tener el SDK de .NET instalado.
2.  Navega a la carpeta del proyecto:
    ```bash
    cd Deserialization
    ```
3.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```

## Salida Esperada

El programa mostrará en la consola los datos deserializados (Nombre y Edad) para cada método, junto con el tiempo en milisegundos que tomó la operación.

Ejemplo de salida:
```text
Binary Deserialization - UseName: María García, UserAge: 28
Binary Deserialization took: X ms
XML Deserialization - UseName: Bob, UserAge: 30
XML Deserialization took: Y ms
JSON Deserialization - UserName: Charlie, UserAge: 28
JSON Deserialization took: Z ms
```
