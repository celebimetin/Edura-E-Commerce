using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Edura.WebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}