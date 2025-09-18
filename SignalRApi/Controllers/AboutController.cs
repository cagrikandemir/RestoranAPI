using AutoMapper;
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
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<About>>(_aboutService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<About>(_aboutService.TGetById(Id)));
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateAboutDto createAboutDto)
        {
           var about = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(about);
            return Ok("About Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateAboutDto updateAboutDto) 
        {
            var about = _mapper.Map<About>(updateAboutDto);
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
