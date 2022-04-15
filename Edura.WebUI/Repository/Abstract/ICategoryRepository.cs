using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using System.Collections;
using System.Collections.Generic;

namespace Edura.WebUI.Repository.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IEnumerable<CategoryProductCauntModel> GetAllWithProductCaunt();
    }
}