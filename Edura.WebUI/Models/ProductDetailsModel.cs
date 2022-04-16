using Edura.WebUI.Entity;
using System.Collections.Generic;

namespace Edura.WebUI.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<ProductAttribute> ProductAttributes { get; set; }
        public List<Category> Categories { get; set; }
    }
}