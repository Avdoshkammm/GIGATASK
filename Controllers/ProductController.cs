using GIGATASK.Models;
using GIGATASK.Services;
using Microsoft.AspNetCore.Mvc;

namespace GIGATASK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Get all products")]
        public async Task<ActionResult<Product>> GetAllProduct()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("Get product by id")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost("Add product")]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
             return Ok(await _productService.CreateProduct(product));
        }

        [HttpPut("Update product by id")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product, int id)
        {
              return Ok(await _productService.UpdateProduct(product, id));
        }

        [HttpDelete("Delete product by id")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id, Product product)
        {
              return Ok(await _productService.DeleteProduct(id, product));
        }
    }
}
