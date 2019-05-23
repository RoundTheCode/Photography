using Photography.Infrastructure.DbContext;
using Photography.Infrastructure.Types.Category.Data;
using System.Collections.Generic;
using System.Linq;


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

        public virtual new CategoryEntity GetByHash(string hash)
        {
            return base.GetByHash(hash);
        }

        public virtual IEnumerable<CategoryEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual CategoryEntity GetBySlug(string slug)
        {
            return _entities.FirstOrDefault(x => x.Slug == slug);
        }
    }
}
