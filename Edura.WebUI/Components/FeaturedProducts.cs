using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Edura.WebUI.Components
{
    public class FeaturedProducts : ViewComponent
    {
        private IProductRepository _productRepository;

        public FeaturedProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_productRepository.GetAll().Where(x => x.IsApproved && x.IsFeatured).ToList());
        }
    }
}