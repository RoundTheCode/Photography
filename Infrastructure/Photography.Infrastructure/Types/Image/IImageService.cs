using Photography.Infrastructure.Types.Image.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types.Image
{
    public partial interface IImageService : IBaseSelectService<ImageEntity>
    {
        IEnumerable<ImageEntity> GetAllByCategory(int id);
    }
}
