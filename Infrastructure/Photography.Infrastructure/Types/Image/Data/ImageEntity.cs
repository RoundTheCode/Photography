using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        [NotMapped]
        public virtual ImageAttributeEntity FullImageAttributes
        {
            get => ImageAttributes?.FirstOrDefault(i => i.Main);
        }

        [NotMapped]
        public virtual ImageAttributeEntity ThumbnailImageAttributes
        {
            get => ImageAttributes?.FirstOrDefault(i => !i.Main);
        }

    }
}
