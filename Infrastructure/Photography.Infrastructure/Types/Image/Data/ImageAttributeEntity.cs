using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Photography.Infrastructure.Types.Image.Data
{
    [Table("ImageAttribute", Schema = "photo")]
    public partial class ImageAttributeEntity : BaseEntity
    {
        public virtual int ImageId { get; set; }

        [MaxLength(400)]
        public virtual string Path { get; set; }

        [MaxLength(10)]
        public virtual string Extension { get; set; }

        public virtual int Width { get; set; }

        public virtual int Height { get; set; }

        [DefaultValue(false)]
        public virtual bool Main { get; set; }
    }
}
