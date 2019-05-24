using Photography.Infrastructure.DbContext;
using Photography.Infrastructure.Types.Enquiry.Data;

namespace Photography.Infrastructure.Types.Enquiry
{
    public partial class EnquiryService : BaseService<EnquiryEntity>, IEnquiryService
    {
        public EnquiryService(PhotographyDbContext context) : base(context, context.EnquiryEntities)
        {
        }

        public virtual new EnquiryEntity Insert(EnquiryEntity entity)
        {
            return base.Insert(entity);
        }
    }
}
