# Proyecto de Serialización

Este proyecto es una aplicación de consola en .NET que demuestra cómo guardar el estado de un objeto en diferentes formatos: **Binario**, **XML** y **JSON**.

## Descripción

La aplicación crea un objeto de ejemplo (`Person`) con datos predefinidos ("Alice", 30 años) y lo serializa (guarda) en tres archivos diferentes, mostrando las distintas formas de persistir datos en .NET.

## Métodos de Serialización

1.  **Serialización Binaria**:
    *   Usa `System.IO.BinaryWriter`.
    *   Escribe los datos en `person.dat` de forma secuencial y compacta.
    *   *Uso*: Eficiente para almacenamiento interno, pero no leíble por humanos.

2.  **Serialización XML**:
    *   Usa `System.Xml.Serialization.XmlSerializer`.
    *   Genera un archivo `person.xml` con etiquetas estructuradas.
    *   *Uso*: Intercambio de datos legacy o configuraciones legibles.

3.  **Serialización JSON**:
    *   Usa `System.Text.Json.JsonSerializer` (nativo en .NET Core / 5+).
    *   Genera un archivo `person.json`.
    *   *Uso*: Estándar moderno para APIs web y almacenamiento ligero.

## Cómo Ejecutar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd Serialization
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```
3.  Al finalizar, encontrarás tres nuevos archivos en la carpeta de salida (o en la raíz del proyecto dependiendo de la configuración): `person.dat`, `person.xml`, y `person.json`.
