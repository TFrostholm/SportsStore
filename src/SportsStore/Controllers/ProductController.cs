using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Interfaces;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult List(int page = 1)
            => View(new ProductsListViewModel
            {
                Products = _repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((page -1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }
            });
    }
}