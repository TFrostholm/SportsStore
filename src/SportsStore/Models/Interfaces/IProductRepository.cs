using System.Collections.Generic;

namespace SportsStore.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}