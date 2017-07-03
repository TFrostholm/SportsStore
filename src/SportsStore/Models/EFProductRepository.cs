using System.Collections.Generic;
using SportsStore.Models.Interfaces;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDBContext _context;

        public EFProductRepository(ApplicationDBContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Product> Products => _context.Products;
    }
}