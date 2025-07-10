using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCasesService _moneyCasesService;

        public MoneyCasesController(IMoneyCasesService moneyCasesService)
        {
            _moneyCasesService = moneyCasesService;
        }
        [HttpGet("[action]")]
        public IActionResult GetTotalMoneyCases()
        {
            return Ok(_moneyCasesService.TGetTotalMoneyCases());
        }
    }
}
