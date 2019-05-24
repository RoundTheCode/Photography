using Photography.Infrastructure.Types.Category.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Infrastructure.Types.Image.Data
{
    [Table("ImageCategory", Schema = "photo")]
    public partial class ImageCategoryEntity : BaseEntity
    {
        public virtual int ImageId { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual bool Main { get; set; }

        public virtual int Order { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryEntity Category { get; set; }

    }
}
