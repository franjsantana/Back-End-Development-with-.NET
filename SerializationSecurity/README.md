# Proyecto SerializationSecurity

Este proyecto demuestra prácticas de seguridad esenciales al trabajar con **Serialización** en .NET, para mitigar riesgos como la exposición de datos sensibles y ataques de deserialización insegura.

## Descripción

El código (`Program.cs`) implementa un flujo seguro para manejar los datos de un usuario (`User`), abarcando desde la creación hasta la recuperación de los mismos.

## Principios de Seguridad Implementados

1.  **Validación de Entrada**:
    *   Antes de serializar, se verifica que los campos requeridos (Nombre, Email, Password) no estén vacíos. Si los datos son inválidos, se aborta la operación.

2.  **Encriptación de Datos Sensibles**:
    *   El campo `Password` **NO** se guarda en texto plano.
    *   Se utiliza un método `EncryptData` (simulado en este ejemplo con Base64 por simplicidad) para ofuscar la contraseña antes de convertir el objeto a JSON.
    *   *Nota*: En un escenario real, se debe usar criptografía fuerte (como AES).

3.  **Integridad de Datos (Hashing)**:
    *   Se incluye una función `GenerateHash` utilizando **SHA256**. Esto permite generar una "huella digital" del objeto para verificar posteriormente que los datos no han sido manipulados.

4.  **Deserialización Segura (Trusted Source)**:
    *   La función `DeserializeUserData` incluye un chequeo de seguridad (`isTrustedSource`).
    *   **Regla de Oro**: Nunca deserialices datos de fuentes no confiables sin validación estricta, ya que es un vector de ataque común (Insecure Deserialization).

## Cómo Ejecutar

1.  Navega a la carpeta del proyecto:
    ```bash
    cd SerializationSecurity
    ```
2.  Ejecuta la aplicación:
    ```bash
    dotnet run
    ```

## Salida Esperada

Verás en la consola los datos serializados en formato JSON. Nota cómo el campo `Password` aparece codificado (ej. `U2VjdXJlUEBzczEyMw==`) en lugar del texto original "SecureP@ss123".

```text
Serialized Data:
{"Name":"Alice","Email":"alice@example.com","Password":"U2VjdXJlUEBzczEyMw=="}
Deserializacion exitosa:
...
```
