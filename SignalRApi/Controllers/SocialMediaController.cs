using AutoMapper;
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
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<SocialMedia>>(_socialMediaService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<SocialMedia>(_socialMediaService.TGetById(Id)));
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateSocialMediaDto createSocialMediaDto)
        {
            var socialmedia = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(socialmedia);
            return Ok("Social Media Added Succesfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);

            _socialMediaService.TUpdate(socialMedia);
            return Ok("Social Media Updated Succesfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _socialMediaService.TGetById(Id);
            _socialMediaService.TDelete(value);
            return Ok("Social Media Deleted Succesfully");

        }
    }
}
