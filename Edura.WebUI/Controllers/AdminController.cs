using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public AdminController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CatalogList()
        {
            var model = new CatalogListModel()
            {
                Categories = _categoryRepository.GetAll().ToList(),
                Products = _productRepository.GetAll().ToList()
            };

            return View(model);
        }
    }
}