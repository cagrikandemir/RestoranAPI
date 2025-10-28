using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("[action]")]
        public IActionResult GetBasketByMenuTableNumber(int Id)
        {
            return Ok(_basketService.TGetBasketByMenuTableNumber(Id));
        }
        [HttpGet("[action]")]
        public IActionResult BasketListByMenuTableWithProductName(int Id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableId == Id).Select(z => new ResultBasketListWithProductName
            {
                BasketId = z.BasketId,
                Count = z.Count,
                MenuTableId = z.MenuTableId,
                Price = z.Price,
                ProductId = z.ProductId,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
        [HttpPost("[action]")]
        public IActionResult AddBasket(CreateBasketDto createBasketDto)
        {
            var context= new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = createBasketDto.MenuTableId,
                TotalPrice = createBasketDto.TotalPrice,
                Price = context.Products.Where(x => x.ProductId == createBasketDto.ProductId).Select(y => y.Price).FirstOrDefault()

            });
            return Ok("Ürünler Sepete Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult DeleteBasket(int Id)
        {
            var value=_basketService.TGetById(Id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Başarıyla Silindi");
        }
    }
}
