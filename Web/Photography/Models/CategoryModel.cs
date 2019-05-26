using Photography.Infrastructure.Types.Category.Data;
using Photography.Infrastructure.Types.Image.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photography.Models
{
    public partial class CategoryModel
    {
        public virtual CategoryEntity Category { get; set; }

        public virtual IEnumerable<ImageEntity> Images { get; set; }
    }
}
