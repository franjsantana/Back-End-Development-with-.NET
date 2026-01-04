using Microsoft.AspNetCore.Mvc;
using Serilog;

[ApiController]
[Route("api/[controller]")]//[ErrorHandling]
public class ErrorHandlingController : ControllerBase
{
    [HttpGet("division")]//Ruta: api/ErrorHandling/division
    public IActionResult GetDivisionResult(int numerador, int denominador)
    {
        try
        {
            var resultado = numerador / denominador;
            return Ok(resultado);
        }
        catch (DivideByZeroException ex)
        {
            Log.Warning(ex, "División por cero - Numerador: {Numerador}", numerador); //Warning
            return BadRequest("No se puede dividir por cero."); //400 Bad Request
        }
    }
}

/*
Para errores DEL USUARIO (como división por cero):
- Manejo específico en el controller
- Status 400 + mensaje útil
- Log como Warning (no es error del sistema)
*/