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


    }
}
