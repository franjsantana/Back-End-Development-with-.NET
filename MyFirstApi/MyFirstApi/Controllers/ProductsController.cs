using Microsoft.AspNetCore.Mvc;
namespace MyFirstApi.Controllers

{
    [ApiController]//atributo que indica que esta clase es un controlador de API
    [Route("api/[controller]")]//define la ruta para este controlador: api/products
    public class ProductsController : ControllerBase
    {
        private static List<string> products = new List<string> //almacena una lista estática de productos
        { 
            "Apple", "Banana", "Orange" 
        };

        [HttpGet]
        public ActionResult<List<string>> Get()//maneja las solicitudes GET a api/products
        {
            return products;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] string newProduct)//maneja las solicitudes POST a api/products
        {
            products.Add(newProduct);  
            return $"Added: {newProduct}";
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string updatedProduct)//maneja las solicitudes PUT a api/products/{id}
        {
            if (id < 0 || id >= products.Count)//verifica si el id es válido
                return NotFound($"Product with id {id} not found");
            
            string oldProduct = products[id];//almacena el producto antiguo para el mensaje de respuesta
            products[id] = updatedProduct;//actualiza el producto en la lista
            return $"Updated: {oldProduct} → {updatedProduct}";
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)//maneja las solicitudes DELETE a api/products/{id}
        {
            if (id < 0 || id >= products.Count)
                return NotFound($"Product with id {id} not found");
            
            string deletedProduct = products[id];//almacena el producto eliminado para el mensaje de respuesta
            products.RemoveAt(id);//elimina el producto de la lista
            return $"Deleted: {deletedProduct}";
        }
    }//class
}//namespace


/* Lo que esto hace:
Define una ruta: api/products

Controla las solicitudes GET a esa ruta

Devuelve una lista de cadenas como nombres de productos */