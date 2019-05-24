using AutoMapper;
using Photography.Infrastructure.Types.Image.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types.Image.Mapping
{
    using Image = Model.Image;
    using ImageAttribute = Model.ImageAttribute;

    public partial class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<ImageEntity, Image>().ConvertUsing(new ImageReadTypeConverter());
            CreateMap<ImageAttributeEntity, ImageAttribute>().ConvertUsing(new ImageAttributeReadTypeConverter());
        }
    }
}
