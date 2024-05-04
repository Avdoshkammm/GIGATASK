using GIGATASK.Models;
using Microsoft.EntityFrameworkCore;

namespace GIGATASK.Data
{
    public class ApplicContext : DbContext
    {
        public ApplicContext(DbContextOptions<ApplicContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
