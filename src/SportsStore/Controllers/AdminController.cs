using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Interfaces;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _repository;

        public AdminController(IProductRepository repository)
        {
            _repository = repository;
        }

        // Todo: Why is this not working? I get a 404...
        //public ActionResult Index => View(_repository.Products);

        public ViewResult Index()
        {
            return View("Index", _repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            return View(_repository.Products.FirstOrDefault(p => p.ProductID == productId));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} had been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
    }
}