using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types.Image.Model
{
    public partial class ImageAttribute
    {
        public virtual string Source { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    }
}
