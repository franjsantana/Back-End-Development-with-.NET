using System;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

public class User
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    // Paso 4: Encriptar datos sensibles antes de la serializacion
    public void EncryptData()
    {
        Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
    }

    // Paso 6: Generar hash para verificar integridad de datos
    public string GenerateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(ToString()));
            return Convert.ToBase64String(hashBytes);
        }
    }

    public override string ToString() => JsonSerializer.Serialize(this);
}//User.cs

public class Program
{
    public static void Main()
    {
        User user = new User { Name = "Alice", Email = "alice@example.com", Password = "SecureP@ss123" };// Paso 1: Crear instancia de User

        // Paso 2: Serialize user data
        string serializedData = SerializeUserData(user);// Serializar datos del usuario
        Console.WriteLine("Serialized Data:\n" + serializedData);

        // Step 5: Deserialice solo desde fuentes confiables
        string trustedSourceData = serializedData; // Assumiendo que esta data proviene de una fuente confiable
        User deserializedUser = DeserializeUserData(trustedSourceData, isTrustedSource: true);// Deserializar datos del usuario desde una fuente confiable

        if (deserializedUser != null)
        {
            Console.WriteLine("Deserializacion exitosa:");
        }
    }//Main

    public static string SerializeUserData(User user)// Serialice los datos del usuario
    {
        // Paso 3: Validacion de entrada
        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password)) 
        {
            Console.WriteLine("Datos de usuario invalidos. Serializacion fallida.");
            return string.Empty;
        }
        user.EncryptData();// Encriptar datos sensibles antes de la serializacion, con esta linea Password":"U2VjdXJlUEBzczEyMw==
        return JsonSerializer.Serialize(user);// Serializar objeto User a JSON 
    }     

    public static User DeserializeUserData(string jsonData, bool isTrustedSource)
    {
        if (!isTrustedSource)
        {
            Console.WriteLine("Deserializacion bloqueada.");
            return null;
        }
        return JsonSerializer.Deserialize<User>(jsonData);
    }
}//Program.cs