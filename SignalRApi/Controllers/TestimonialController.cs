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

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _testimonialService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int Id)
        {
            var value = _testimonialService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial
            {
                Name = createTestimonialDto.Name,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Title = createTestimonialDto.Title,
                Status = createTestimonialDto.Status
            };
            _testimonialService.TAdd(testimonial);
            return Ok("Testimonial Added Succesfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                Name = updateTestimonialDto.Name,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Title = updateTestimonialDto.Title,
                Status = updateTestimonialDto.Status
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Testimonial Updated Succesfully");
        }
        [HttpDelete("[action]")]
        public IActionResult Delete(int Id)
        {
            var value = _testimonialService.TGetById(Id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial Deleted Succesfully");
            
        }
    }
}
