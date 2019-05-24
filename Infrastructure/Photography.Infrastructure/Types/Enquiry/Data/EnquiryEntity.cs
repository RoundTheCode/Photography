using Photography.Infrastructure.Types.Image.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Photography.Infrastructure.Types.Enquiry.Data
{
    [Table("Enquiry", Schema = "photo")]
    public partial class EnquiryEntity : BaseEntity
    {
        public virtual int ImageId { get; set; }

        [MaxLength(100)]
        public virtual string Name { get; set; }

        [MaxLength(100)]
        public virtual string Email { get; set; }
        public virtual string Comments { get; set; }

        [ForeignKey("ImageId")]
        public virtual ImageEntity Image { get; set; }

    }
}
