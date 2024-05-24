using GIGATASK.Data;
using GIGATASK.Interfaces;
using GIGATASK.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GIGATASK.Services
{
    public class ProductService : IGenericService<Product>
    {
        private readonly ApplicContext _context;


        
        public ProductService(ApplicContext context)
        {
            _context = context;
        }

        public Task<List<Product>> GetAllProducts()
        {
            return _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                Console.WriteLine("No in db");
                return null;
            }

            return product;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        private bool ProductAvaliable(int id)
        {
            return (_context.Products?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        public async Task<Product> UpdateProduct(Product product, int id)
        {
            if(id != product.Id)
            {
                Console.WriteLine("No in db");
            }
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if(!ProductAvaliable(id))
                {
                    Console.WriteLine(ex.ToString());
                }
                else
                {
                    throw;
                }
            }
            return product;
        }

        public async Task<Product> DeleteProduct(int id, Product product)
        {
            if(_context == null)
            {
                return product;
            }
            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
            {
                return product;
            }
            _context.Products.Remove(prod);

            await _context.SaveChangesAsync();
            return product;
        }



/*
        public Task<Product> DeleteProduct(int id, Product product)
        {
            if (_context == null)
            {
                return product;
            }

            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
            {
                return product;
            }
            _context.Products.Remove(prod);

            await _context.SaveChangesAsync();
            return product;
        }

*/

        //public async Task<Product> UpdateProduct(Product product, int id)
        //{
        //    return product;
        //}
        /*
        public async Task<Product> UpdateProduct(int id,Product product)
        {
            //throw new NotImplementedException();
            if(id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!ProductAvaliable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ProductAvaliable(int id)
        {
            return (_context.Products?.Any(x => x.Id == id)).GetValueOrDefault();
        }
        public async Task<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Product> UpdateProduct(Product entity, int id)
        {
            throw new NotImplementedException();
        }

        Task IGenericService<Product>.DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }*/


    }
}
