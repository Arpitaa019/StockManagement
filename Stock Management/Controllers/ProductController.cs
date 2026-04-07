using Microsoft.AspNetCore.Mvc;
using StockManagement.Service.Repo.Services;

namespace Stock_Management.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductById(id);
            if (product == null) return NotFound($"Product with ID {id} not found.");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _service.CreateProduct(product);
            return Ok("Product created successfully.");
        }

        // PUT: api/product
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            await _service.UpdateProduct(product);
            return Ok("Product updated successfully.");
        }
        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
            return Ok("Product deleted successfully.");
        }

    }
}
