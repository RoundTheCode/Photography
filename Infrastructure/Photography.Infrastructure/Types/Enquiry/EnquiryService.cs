using Photography.Infrastructure.DbContext;
using Photography.Infrastructure.Types.Enquiry.Data;
using System.Threading.Tasks;

namespace Photography.Infrastructure.Types.Enquiry
{
    public partial class EnquiryService : BaseService<EnquiryEntity>, IEnquiryService
    {
        public EnquiryService(PhotographyDbContext context) : base(context, context.EnquiryEntities)
        {
        }

        public virtual new async Task<EnquiryEntity> InsertAsync(EnquiryEntity entity)
        {
            return await base.InsertAsync(entity);
        }
    }
}
