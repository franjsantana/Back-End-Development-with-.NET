using System.Xml.Serialization;
using System.Text.Json;

public class Project
{
    public class Person
    {
        public string UserName { get; set; } = string.Empty;
        public int UserAge { get; set; }
    }


    static void Main()
    {
        Person samplePerson = new Person { UserName = "Alice", UserAge = 30 };
        
        // Binary Serialization
        using (FileStream fs = new FileStream("person.dat", FileMode.Create))// Crea un FileStream para el archivo de salida
        {
            BinaryWriter writer = new BinaryWriter(fs);// Crea un BinaryWriter para escribir datos binarios
            writer.Write(samplePerson.UserName);// Escribe el nombre de usuario
            writer.Write(samplePerson.UserAge);// Escribe la edad del usuario
        }
        Console.WriteLine("Serialization complete.");

        // XML Serialization
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));// Crea un XmlSerializer para la clase Person
        using (StreamWriter writer = new StreamWriter("person.xml"))// Crea un StreamWriter para el archivo XML de salida
        {
            xmlSerializer.Serialize(writer, samplePerson);// Serializa el objeto Person y lo escribe en el archivo XML
        }
        Console.WriteLine("XML Serialization complete.");
        
        // JSON Serialization
        string jsonString = JsonSerializer.Serialize(samplePerson);// Serializa el objeto Person a una cadena JSON 
        File.WriteAllText("person.json", jsonString);// Escribe la cadena JSON en el archivo
        Console.WriteLine("JSON Serialization complete.");
    }// End of Main   
}// End of Program.cs
