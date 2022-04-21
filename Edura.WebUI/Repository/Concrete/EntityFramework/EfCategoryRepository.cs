using System.Collections.Generic;
using System.Linq;
using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(EduraContext context) : base(context) { }

        public EduraContext EduraContext
        {
            get { return _context as EduraContext; }
        }
        public IEnumerable<CategoryProductCauntModel> GetAllWithProductCaunt()
        {
            return GetAll().Select(x => new CategoryProductCauntModel()
            {
                CategoryId = x.Id,
                CategoryName = x.CategoryName,
                Caunt = x.ProductCategories.Count
            });
        }

        public void RemoveFromCategory(int ProductId, int CategoryId)
        {
            var cmd = $"delete from ProductCategory where ProductId={ProductId} and CategoryId={CategoryId}";
            _context.Database.ExecuteSqlCommand(cmd);
        }
    }
}