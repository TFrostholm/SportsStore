using System.Collections.Generic;
using SportsStore.Models.Interfaces;

namespace SportsStore.Models
{
    /// <summary>
    /// Temporary until data storage is implemented
    /// </summary>
    public class FakeProductRepository /*: IProductRepository*/
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        };
    }
}