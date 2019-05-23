
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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
        public virtual ActionResult PostEnquiry(Enquiry enquiry, string imageHash)
        {
            // Does the image exist?
            var image = _imageService.GetByHash(imageHash);

            if (image == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }

            var entity = _mapper.Map<EnquiryEntity>(enquiry);
            entity.Image = image;
            entity.ImageId = image.Id;

            _enquiryService.Insert(entity);

            return new JsonResult(new { Status = "Success" });
        }
    }
}
