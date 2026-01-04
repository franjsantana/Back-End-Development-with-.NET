using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Text.Json;


public class Program
{
    public class Person
    {
        public string UserName { get; set; } = string.Empty;
        public int UserAge { get; set; }
    }

static void Main()
    {
        // Bytes exactos del archivo person.dat
        byte[] fileBytes = new byte[] {
            0x0C, 0x4D, 0x61, 0x72, 0xED, 0x61, 0x20, 0x47, 0x61, 0x72, 0x63, 0xED, 0x61, 
            0x1C, 0x00, 0x00, 0x00
        };

        File.WriteAllBytes("person.dat", fileBytes);
        
        // Binary Deserialization

        try
        {
            Stopwatch stopwatch = Stopwatch.StartNew();// Medir tiempo de deserialización

            using (var fs = new FileStream("person.dat", FileMode.Open))// Abrir el archivo en modo lectura
            using (var reader = new BinaryReader(fs))// Leer el archivo binario
            {
            var deserializedPerson = new Person// Crear una nueva instancia de Person
            {
                UserName = reader.ReadString(),// Leer el nombre de usuario
                UserAge = reader.ReadInt32()// Leer la edad del usuario
            };

            stopwatch.Stop();// Detener el cronómetro
            Console.WriteLine($"Binary Deserialization - UseName: {deserializedPerson.UserName}, UserAge: {deserializedPerson.UserAge}");
            Console.WriteLine($"Binary Deserialization took: {stopwatch.ElapsedMilliseconds} ms");
       
            }   
        }
            catch(Exception ex){
                Console.WriteLine($"An error occurred during binary deserialization: {ex.Message}");
            }
   
        // XML Deserialization

        try
        {
            var xmlData = "<Person><UserName>Bob</UserName><UserAge>30</UserAge></Person>";
            var serializer = new XmlSerializer(typeof(Person));// Crear un serializador XML para la clase Person

            Stopwatch stopwatch = Stopwatch.StartNew();

            using (var reader = new StringReader(xmlData))// Leer la cadena XML
            {
                var deserializedPerson = (Person)serializer.Deserialize(reader);// Deserializar el objeto Person desde XML
                stopwatch.Stop();
                Console.WriteLine($"XML Deserialization - UseName: {deserializedPerson.UserName}, UserAge: {deserializedPerson.UserAge}");
                Console.WriteLine($"XML Deserialization took: {stopwatch.ElapsedMilliseconds} ms");
            } 
        }
            catch(Exception ex){
                Console.WriteLine($"An error occurred during XML deserialization: {ex.Message}");
        } 

        // JSON Deserialization
        try
        {
            var jsonData = "{\"UserName\":\"Charlie\",\"UserAge\":28}";

            Stopwatch stopwatch = Stopwatch.StartNew();

            var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonData);// Deserializar el objeto Person desde JSON
            Console.WriteLine($"JSON Deserialization - UserName: {deserializedPerson.UserName}, UserAge: {deserializedPerson.UserAge}");
            Console.WriteLine($"JSON Deserialization took: {stopwatch.ElapsedMilliseconds} ms");
        }
        catch(Exception ex){
            Console.WriteLine($"An error occurred during JSON deserialization: {ex.Message}");
        }    
    }//Main
}//Program.cs
