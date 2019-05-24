using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types.Image.Model
{
    public partial class Image
    {
        public virtual string Hash { get; set; }
        public virtual string Title { get; set; }
        public virtual ImageAttribute FullImageAttributes { get; set; }
        public virtual ImageAttribute ThumbnailImageAttributes { get; set; }
    }
}
