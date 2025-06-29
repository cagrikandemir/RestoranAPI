using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _socialMediaService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int Id)
        {
            var value = _socialMediaService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia socialmedia = new SocialMedia
            {
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
                Icon = createSocialMediaDto.Icon
            };
            _socialMediaService.TAdd(socialmedia);
            return Ok("Social Media Added Succesfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia
            {
                SocialMediaId = updateSocialMediaDto.SocialMediaId,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                Icon = updateSocialMediaDto.Icon
            };
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Social Media Updated Succesfully");
        }
        [HttpDelete("[action]")]
        public IActionResult Delete(int Id)
        {
            var value = _socialMediaService.TGetById(Id);
            _socialMediaService.TDelete(value);
            return Ok("Social Media Deleted Succesfully");

        }
    }
}
