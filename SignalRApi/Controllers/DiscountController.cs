using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Discount>>(_discountService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Discount>(_discountService.TGetById(Id)));
        }
        [HttpGet("[action]/{id}")]
        public IActionResult StatusChangeToActive(int id)
        {
            _discountService.TStatusChangeToActive(id);
            return Ok("Status Changed To Active");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult StatusChangeToPassive(int id)
        {
            _discountService.TStatusChangeToPassive(id);
            return Ok("Status Changed To Passive");
        }
        [HttpGet("[action]")]
        public IActionResult GetListDiscountByTrue()
        {
            var values = _discountService.TGetListDiscountByTrue();
            return Ok(values);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateDiscountDto createDiscountDto)
        {
            var discount = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(discount);
            return Ok("About Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateDiscountDto updateDiscountDto)
        {
            var discount = _mapper.Map<Discount>(updateDiscountDto);

            _discountService.TUpdate(discount);
            return Ok("About Updated Successfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _discountService.TGetById(Id);
            _discountService.TDelete(value);
            return Ok("Discount Deleted Successfully");
        }
    }
}
