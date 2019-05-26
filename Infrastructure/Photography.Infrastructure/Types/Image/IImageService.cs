using Photography.Infrastructure.Types.Image.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Infrastructure.Types.Image
{
    public partial interface IImageService : IBaseSelectService<ImageEntity>
    {
        Task<IEnumerable<ImageEntity>> GetAllByCategoryAsync(int id);
    }
}
