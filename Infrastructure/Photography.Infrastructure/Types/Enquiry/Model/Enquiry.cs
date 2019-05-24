using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types.Enquiry.Model
{
    public partial class Enquiry
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Comments { get; set; }
        public virtual string ImageHash { get; set; }
    }
}
