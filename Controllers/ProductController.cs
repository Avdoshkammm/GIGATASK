using GIGATASK.Data;
using GIGATASK.Models;
using GIGATASK.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAllProduct()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
             return Ok(await _productService.AddProduct(product));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
              return Ok(await _productService.UpdateProduct(product));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
              return Ok(await _productService.DeleteProduct(id));
        }

    }
}
