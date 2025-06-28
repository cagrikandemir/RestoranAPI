using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _bookingService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int Id)
        {
            var value = _bookingService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking
            {
                Name = createBookingDto.Name,
                Mail = createBookingDto.Mail,
                Phone = createBookingDto.Phone,
                PersonCount = createBookingDto.PersonCount,
                Date = createBookingDto.Date
            };
            _bookingService.TAdd(booking);
            return Ok("Booking Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update (UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking
            {
                BookingId = updateBookingDto.BookingId,
                Name = updateBookingDto.Name,
                Mail = updateBookingDto.Mail,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date
            };
            _bookingService.TUpdate(booking);
            return Ok("Booking Updated Successfully");
        }
        [HttpDelete("[action]")]
        public IActionResult Delete(int Id)
        {
            var value = _bookingService.TGetById(Id);
                _bookingService.TDelete(value);
                return Ok("Booking Deleted Successfully");
        }
    }
}
