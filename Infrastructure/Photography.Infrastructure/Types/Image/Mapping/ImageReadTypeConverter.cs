using AutoMapper;
using Photography.Infrastructure.Types.Image.Data;
using Photography.Infrastructure.Types.Image.Model;
using System.Linq;

namespace Photography.Infrastructure.Types.Image.Mapping
{
    using Image = Model.Image;

    public partial class ImageReadTypeConverter : ITypeConverter<ImageEntity, Image>
    {

        public virtual Image Convert(ImageEntity entity, Image model, ResolutionContext context)
        {
            if (entity == null)
            {
                return null;
            }

            model = model ?? new Image();
            model.Hash = entity.Hash;
            model.Title = entity.Title;

            if (entity.ImageAttributes != null && entity.ImageAttributes.Count > 0)
            {
                model.FullImageAttributes = context.Mapper.Map<ImageAttributeEntity, ImageAttribute>(entity.ImageAttributes.FirstOrDefault(s => s.Main));
                model.ThumbnailImageAttributes = context.Mapper.Map<ImageAttributeEntity, ImageAttribute>(entity.ImageAttributes.FirstOrDefault(s => !s.Main));
            }

            return model;
        }
    }
}
