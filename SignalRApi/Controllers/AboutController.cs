using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _aboutService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            var value = _aboutService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateAboutDto createAboutDto)
        {
            About about = new About
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };
            _aboutService.TAdd(about);
            return Ok("About Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateAboutDto updateAboutDto) 
        {
            About about = new About
            {
                AboutId = updateAboutDto.AboutId,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            };
            _aboutService.TUpdate(about);
            return Ok("About Updated Successfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete (int Id)
        {
            var value= _aboutService.TGetById(Id);
            _aboutService.TDelete(value);
            return Ok("About Deleted Successfully");
        }
    }
}
