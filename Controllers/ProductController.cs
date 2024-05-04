using GIGATASK.Data;
using GIGATASK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GIGATASK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicContext _context;
        //public ProductController(ApplicContext context)
        //{
        //    _context = context;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAllProduct()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<List<Product>>> AddProduct(Product allProduct)
        {
            _context.Products.Add(allProduct);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product allProduct)
        {
            var dbProduct = await _context.Products.FindAsync(allProduct.Id);
            if(dbProduct == null)
            {
                return BadRequest("Product not found");
            }
            allProduct.Id = dbProduct.Id;
            allProduct.Name = dbProduct.Name;
            allProduct.Description = dbProduct.Description;

            _context.Products.Update(allProduct);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(Product allProduct)
        {
            var dbProduct = await _context.Products.FindAsync(allProduct.Id);
            if(dbProduct == null)
            {
                return BadRequest("Not found");
            }
            _context.Products.Remove(allProduct);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

    }
}
