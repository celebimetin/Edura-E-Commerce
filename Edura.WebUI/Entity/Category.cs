using System.Collections.Generic;

namespace Edura.WebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}