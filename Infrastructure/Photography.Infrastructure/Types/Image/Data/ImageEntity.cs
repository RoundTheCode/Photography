using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Photography.Infrastructure.Types.Image.Data
{
    [Table("Image", Schema = "photo")]
    public partial class ImageEntity : BaseEntity
    {
        [MaxLength(100), Column(Order = 2)]
        public virtual string Title { get; set; }

        [ForeignKey("ImageId")]
        public virtual ICollection<ImageAttributeEntity> ImageAttributes { get; set; }

        [ForeignKey("ImageId")]
        public virtual ICollection<ImageCategoryEntity> ImageCategories { get; set; }

    }
}
