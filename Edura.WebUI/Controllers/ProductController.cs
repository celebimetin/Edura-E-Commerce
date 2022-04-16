using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Edura.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(_productRepository.GetAll().Where(x => x.Id == id)
                .Include(x => x.Images)
                .Include(x => x.Attributes)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category).Select(x => new ProductDetailsModel()
                {
                    Product = x,
                    ProductImages = x.Images,
                    ProductAttributes = x.Attributes,
                    Categories = x.ProductCategories.Select(y => y.Category).ToList()
                }).FirstOrDefault());
        }
    }
}