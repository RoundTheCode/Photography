using Microsoft.EntityFrameworkCore;
using Photography.Infrastructure.DbContext;
using Photography.Infrastructure.Types.Category.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photography.Infrastructure.Types.Category
{
    public partial class CategoryService : BaseService<CategoryEntity>, ICategoryService
    {
        public CategoryService(PhotographyDbContext context) : base(context, context.CategoryEntities)
        {
        }

        public virtual new CategoryEntity GetById(int id)
        {
            return base.GetById(id);
        }

        public virtual new async Task<CategoryEntity> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public virtual new CategoryEntity GetByHash(string hash)
        {
            return base.GetByHash(hash);
        }

        public virtual new async Task<CategoryEntity> GetByHashAsync(string hash)
        {
            return await base.GetByHashAsync(hash);
        }

        public virtual async Task<IEnumerable<CategoryEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual CategoryEntity GetBySlug(string slug)
        {
            var category = GetBySlugAsync(slug);
            category.Wait();

            return category.Result;
        }

        public virtual async Task<CategoryEntity> GetBySlugAsync(string slug)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Slug == slug);
        }
    }
}
