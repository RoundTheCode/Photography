using Photography.Infrastructure.Types.Category.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types.Category
{
    public partial interface ICategoryService : IBaseSelectService<CategoryEntity>
    {
        IEnumerable<CategoryEntity> GetAll();

        CategoryEntity GetBySlug(string slug);
    }
}
