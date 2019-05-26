using Microsoft.AspNetCore.Mvc;
using Photography.Infrastructure.Types.Category.Data;
using Photography.Infrastructure.Types.Image;
using Photography.Models;
using System.Threading.Tasks;

namespace Photography.Controllers
{
    public partial class CategoryController : Controller
    {
        protected readonly IImageService _imageService;

        public CategoryController(
            IImageService imageService
            )
        {
            _imageService = imageService;
        }

        public async Task<IActionResult> Listing()
        {
            var category = ControllerContext.RouteData.Values["category"] != null ? (CategoryEntity)ControllerContext.RouteData.Values["category"] : null;

            if (category == null)
            {
                return Content("Not Found");
            }
            
            var images = await _imageService.GetAllByCategoryAsync(category.Id);

            return View(new CategoryModel { Category = category, Images = images } );
        }
    }

}
