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

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _discountService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            var value = _discountService.TGetById(Id);
            return Ok(value);
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
            Discount discount = new Discount
            {
                Title = createDiscountDto.Title,
                Despcription = createDiscountDto.Despcription,
                Amount = createDiscountDto.Amount,
                ImageUrl = createDiscountDto.ImageUrl
            };
            _discountService.TAdd(discount);
            return Ok("About Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateDiscountDto updateDiscountDto)
        {
            Discount discount = new Discount
            {
                DiscountId = updateDiscountDto.DiscountId,
                Title = updateDiscountDto.Title,
                Despcription = updateDiscountDto.Despcription,
                Amount = updateDiscountDto.Amount,
                ImageUrl = updateDiscountDto.ImageUrl
            };
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
