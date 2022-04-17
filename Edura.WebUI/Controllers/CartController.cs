using System;
using Edura.WebUI.Entity;
using Edura.WebUI.Infrastructure;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;

        public CartController(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        public IActionResult AddToCart(int productId, int qauntity = 1)
        {
            var product = _productRepository.Get(productId);
            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, qauntity);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var product = _productRepository.Get(productId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(OrderDetails model)
        {
            var cart = GetCart();
            if (cart.Products.Count == 0)
            {
                ModelState.AddModelError("Ürün yok", "Sepetinizde ürün yok");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.ClearAll();
                SaveCart(cart);
                return View("Completed");
            }
            return View(model);
        }

        private void SaveOrder(Cart cart, OrderDetails details)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.TotalPrice();
            order.OrderDate = DateTime.Now;
            order.OrderState = UnumOrderState.Waiting;
            order.UserName = User.Identity.Name;

            order.AdresTanimi = details.AdresTanimi;
            order.Adres = details.Adres;
            order.Sehir = details.Sehir;
            order.Semt = details.Semt;
            order.Telefon = details.Telefon;

            foreach (var item in cart.Products)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = item.Quantity;
                orderLine.Price = item.Product.Price;
                orderLine.ProductId = item.Product.Id;

                order.OrderLines.Add(orderLine);
            }
            _orderRepository.Add(order);
            _orderRepository.Save();
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }
    }
}