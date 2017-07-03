using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Interfaces;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult List() => View(_repository.Products);
    }
}