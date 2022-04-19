using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                _categoryRepository.Save();

                return Ok(category);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", file.FileName);
                    var path_thumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products\\thumb", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        product.Image = file.FileName;
                    }
                    using (var stream = new FileStream(path_thumb, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                product.DateAdded = DateTime.Now;
                _productRepository.Add(product);
                _productRepository.Save();
                return RedirectToAction("CatalogList");
            }
            return View(product);
        }
    }
}