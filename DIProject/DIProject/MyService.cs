public class MyService : IMyService
{
    private readonly int _serviceId;

    public MyService()//Constructor
    {
        _serviceId = new Random().Next(100000, 999999);//Generate a random 6-digit number   
    }

    public void LogCreation(string message)//Metodo para registrar la creacion del servicio con un mensaje
    {
        Console.WriteLine($"{message} - Service ID: {_serviceId}");
    }
}