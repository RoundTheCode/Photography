
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Photography.Infrastructure.Types.Enquiry;
using Photography.Infrastructure.Types.Enquiry.Data;
using Photography.Infrastructure.Types.Enquiry.Model;
using Photography.Infrastructure.Types.Image;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Photography.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public partial class EnquiryController : ControllerBase
    {
        protected readonly IImageService _imageService;
        protected readonly IMapper _mapper;
        protected readonly IEnquiryService _enquiryService;

        public EnquiryController(
            IImageService imageService,
            IMapper mapper,
            IEnquiryService enquiryService
            )
        {
            _imageService = imageService;
            _mapper = mapper;
            _enquiryService = enquiryService;
        }


        [HttpPost("[action]")]
        public virtual async Task<IActionResult> PostEnquiry(Enquiry enquiry, string imageHash)
        {
            // Does the image exist?
            var image = await _imageService.GetByHashAsync(imageHash);

            if (image == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }

            var entity = _mapper.Map<EnquiryEntity>(enquiry);
            entity.Image = image;
            entity.ImageId = image.Id;

            await _enquiryService.InsertAsync(entity);

            return new JsonResult(new { Status = "Success" });
        }
    }
}
