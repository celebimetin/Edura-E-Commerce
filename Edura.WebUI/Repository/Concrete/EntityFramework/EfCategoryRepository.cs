using System.Collections.Generic;
using System.Linq;
using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(EduraContext context) : base(context) { }

        public IEnumerable<CategoryProductCauntModel> GetAllWithProductCaunt()
        {
            return GetAll().Select(x => new CategoryProductCauntModel()
            {
                CategoryId = x.Id,
                CategoryName = x.CategoryName,
                Caunt = x.ProductCategories.Count
            });
        }
    }
}