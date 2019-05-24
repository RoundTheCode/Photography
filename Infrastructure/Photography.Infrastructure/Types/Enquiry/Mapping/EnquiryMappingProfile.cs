using AutoMapper;
using Photography.Infrastructure.Types.Enquiry.Data;

namespace Photography.Infrastructure.Types.Enquiry.Mapping
{
    using Enquiry = Model.Enquiry;

    public partial class EnquiryMappingProfile : Profile
    {
        public EnquiryMappingProfile()
        {
            CreateMap<Enquiry, EnquiryEntity>().ConvertUsing(new EnquiryWriteTypeConverter());
        }
    }
}
