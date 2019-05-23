using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Photography.Infrastructure.Types
{
    public partial class BaseEntity : IBaseEntity
    {
        [Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Column(Order = 995), MaxLength(300), Required(AllowEmptyStrings = true)]
        public virtual string Hash { get; set; }

        [Column(Order = 996)]
        public virtual bool Enabled { get; set; }

        [Column(Order = 997)]
        public virtual DateTimeOffset Created { get; set; }

        [Column(Order = 998)]
        public virtual DateTimeOffset? Updated { get; set; }

        [Column(Order = 999)]
        public virtual DateTimeOffset? Deleted { get; set; }

    }
}
