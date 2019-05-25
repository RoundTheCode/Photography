using Microsoft.AspNetCore.Mvc;
using Photography.Infrastructure.Types.Category.Data;
using System.Threading.Tasks;

namespace Photography.Controllers
{
    public partial class PageController : Controller
    {
        public IActionResult Render()
        {
            var category = ControllerContext.RouteData.Values["category"] != null ? (CategoryEntity)ControllerContext.RouteData.Values["category"] : null;

            if (category == null)
            {
                return Content("Not Found");
            }

            return View(category);
        }
    }
}
