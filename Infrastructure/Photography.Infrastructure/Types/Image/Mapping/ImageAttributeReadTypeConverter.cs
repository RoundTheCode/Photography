using AutoMapper;
using Photography.Infrastructure.Types.Image.Data;
using Photography.Infrastructure.Types.Image.Model;

namespace Photography.Infrastructure.Types.Image.Mapping
{
    public partial class ImageAttributeReadTypeConverter : ITypeConverter<ImageAttributeEntity, ImageAttribute>
    {
        public virtual ImageAttribute Convert(ImageAttributeEntity entity, ImageAttribute model, ResolutionContext context)
        {
            if (entity == null)
            {
                return null;
            }

            model = model ?? new ImageAttribute();
            model.Source = entity.Path;
            model.Width = entity.Width;
            model.Height = entity.Height;

            return model;
        }
    }
}
