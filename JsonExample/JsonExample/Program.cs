using System;
using Newtonsoft.Json;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Deserialize JSON to Person object
        string json = "{\"Name\":\"Alice\",\"Age\":30}";
        Person person = JsonConvert.DeserializeObject<Person>(json);// Convierte la cadena JSON en un objeto Person
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        /* // Serialize Person object to JSON
        Person person = new Person { Name = "Bob", Age = 25 };
        string json = JsonConvert.SerializeObject(person);// Convierte el objeto Person en una cadena JSON
        Console.WriteLine($"JSON: {json}"); */
    }
}


       
