using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Infrastructure.Types.Category.Data
{
    [Table("Category", Schema = "photo")]
    public partial class CategoryEntity : BaseEntity
    {
        [MaxLength(200)]
        public virtual string Name { get; set; }

        [MaxLength(100)]
        public virtual string Slug { get; set; }
    }
}
