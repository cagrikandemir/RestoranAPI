using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("[action]")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }
        [HttpGet("[action]")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }
        [HttpGet("[action]")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }
    }
}
