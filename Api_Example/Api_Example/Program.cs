var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Basic routes
app.MapGet("/", () => "Welcome to the Simple Web API!");
var items = new List<Item>();

//GET all items
app.MapGet("/items", () => items);

//GET a specific item by ID
app.MapGet("/items/{id}", (int id) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

//POST a new item
app.MapPost("/items", (Item newItem) =>
{
    newItem.Id = items.Count + 1;
    items.Add(newItem);
    return Results.Created($"/items/{newItem.Id}", newItem);// Created item
});

//PUT to update an existing item
app.MapPut("/items/{id}", (int id, Item updatedItem) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    if (item is null)
    {
        return Results.NotFound();
    }
    item.Name = updatedItem.Name;
    return Results.Ok(item);// Updated item
});

//DELETE an item by ID
app.MapDelete("/items/{id}", (int id) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    if (item is null)
    {
        return Results.NotFound();
    }
    items.Remove(item);// Remove item
    return Results.NoContent();// Successful deletion
});

app.Run();

/* Implement the endpoints.

GET all items:
GET a specific item by ID:
POST a new item:
PUT to update an existing item:
DELETE an item by ID: */