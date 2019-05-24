using AutoMapper;
using Photography.Infrastructure.Types.Enquiry.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types.Enquiry.Mapping
{
    using Enquiry = Model.Enquiry;

    public partial class EnquiryWriteTypeConverter : ITypeConverter<Enquiry, EnquiryEntity>
    {
        public virtual EnquiryEntity Convert(Enquiry model, EnquiryEntity entity, ResolutionContext context)
        {
            if (model == null)
            {
                return null;
            }

            entity = entity ?? new EnquiryEntity();
            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.Comments = model.Comments;

            return entity;
        }
    }
}
