using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Testimonial>>(_testimonialService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Testimonial>(_testimonialService.TGetById(Id)));
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(testimonial);
            return Ok("Testimonial Added Succesfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);

            _testimonialService.TUpdate(testimonial);
            return Ok("Testimonial Updated Succesfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _testimonialService.TGetById(Id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial Deleted Succesfully");
            
        }
    }
}
