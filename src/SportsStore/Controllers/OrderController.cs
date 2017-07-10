using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Interfaces;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private Cart _cart;

        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            _cart = cartService;
            _orderRepository = repoService;
        }

        
        public ActionResult Index()
        {
            return View("Checkout");
        }

        public ViewResult List() =>
            View(_orderRepository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = _orderRepository.Orders
                .FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                order.Shipped = true;
                _orderRepository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _orderRepository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}