using Edura.WebUI.Entity;
using System.Collections.Generic;

namespace Edura.WebUI.Models
{
    public class CatalogListModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}