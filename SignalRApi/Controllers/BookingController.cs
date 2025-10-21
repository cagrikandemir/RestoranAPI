using AutoMapper;
using FluentValidation;
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
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _createBookingDtoValidator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> createBookingDtoValidator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _createBookingDtoValidator = createBookingDtoValidator;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Booking>>(_bookingService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Booking>(_bookingService.TGetById(Id)));
        }
        [HttpGet("[action]/{id}")]
        public IActionResult BookingStatusApproved(int id ){
           _bookingService.TBookingStatusApproved(id);
            return Ok("Booking Status Approved");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Booking Status Cancelled");
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateBookingDto createBookingDto)
        {
            var validationResult = _createBookingDtoValidator.Validate(createBookingDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var booking = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(booking);
            return Ok("Booking Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update (UpdateBookingDto updateBookingDto)
        {
            var booking = _mapper.Map<Booking>(updateBookingDto);

            _bookingService.TUpdate(booking);
            return Ok("Booking Updated Successfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _bookingService.TGetById(Id);
            _bookingService.TDelete(value);
            return Ok("Booking Deleted Successfully");
        }
    }
}
