var builder = WebApplication.CreateBuilder(args);

// Añadir servicios al contenedor.
builder.Services.AddControllers();

var app = builder.Build();

// Configura el canal HTTP request pipeline.

// Eliminar el comentario de la siguiente línea si se desea redirigir HTTP a HTTPS
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();