using Microsoft.AspNetCore.Mvc;

// User model 
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("{id}")]
    [Produces("application/json")]
    public ActionResult<User> GetUser(int id)
    {
        var user = new User 
        { 
            Id = id,
            Name = $"User {id}"
        };
        
        return Ok(user);
    }

    // Método para tener más de un endpoint
    [HttpGet]
    [Produces("application/json")]
    public ActionResult<List<User>> GetAllUsers()
    {
        var users = new List<User>
        {
            new User { Id = 1, Name = "User 1" },
            new User { Id = 2, Name = "User 2" },
            new User { Id = 3, Name = "User 3" }
        };
        
        return Ok(users);
    }
}