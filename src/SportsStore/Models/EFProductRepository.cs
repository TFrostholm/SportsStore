using System;
using System.Collections.Generic;
using System.Linq;
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
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Add(product);
            }
            else
            {
                Product dbEntry = _context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);

                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }
    }
}