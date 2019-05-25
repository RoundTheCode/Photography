using Photography.Infrastructure.Types.Category.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Infrastructure.Types.Category
{
    public partial interface ICategoryService : IBaseSelectService<CategoryEntity>
    {
        Task<IEnumerable<CategoryEntity>> GetAllAsync();

        CategoryEntity GetBySlug(string slug);

        Task<CategoryEntity> GetBySlugAsync(string slug);
    }
}
