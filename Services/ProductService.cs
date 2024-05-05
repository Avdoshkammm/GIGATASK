using GIGATASK.Data;
using Microsoft.AspNetCore.Mvc;

namespace GIGATASK.Services
{
    public class ProductService : ControllerBase
    {
        private readonly ApplicContext _context;
        
        public ProductService(ApplicContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = await _context.FirstOrDefaultAsync(p => p.Id == id);

            // try catch 

            return product;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

         public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
        
        public async Task<int> DeleteProduct(int id)
        {
               Product product = await _context.FirstOrDefaultAsync(p => p.Id == id);


// try catch
               _context.Remove(product);
            await _context.SaveChangesAsync();

            return id;
        }    
    }
}
