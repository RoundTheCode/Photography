using Microsoft.EntityFrameworkCore;
using Photography.Infrastructure.DbContext;
using Photography.Infrastructure.Types.Image.Data;
using System.Collections.Generic;
using System.Linq;

namespace Photography.Infrastructure.Types.Image
{
    public partial class ImageService : BaseService<ImageEntity>, IImageService
    {
        public ImageService(PhotographyDbContext context) : base(context, context.ImageEntities)
        {
        }

        public virtual new ImageEntity GetById(int id)
        {
            return base.GetById(id);
        }

        public virtual new ImageEntity GetByHash(string hash)
        {
            return base.GetByHash(hash);
        }

        public virtual IEnumerable<ImageEntity> GetAllByCategory(int id)
        {
            return _entities.Include(s => s.ImageCategories).Include(s => s.ImageAttributes)
                .Where(x => x.ImageCategories.Any(s => s.CategoryId == id)).ToList();
        }


    }
}
