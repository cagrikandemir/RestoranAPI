using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

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
    }
}
