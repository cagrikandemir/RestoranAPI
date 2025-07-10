using Microsoft.AspNetCore.Mvc;
using SignalR.DataAccessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableController(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }
        [HttpGet("[action]")]
        public IActionResult GetTotalMenuTableCount()
        {
            return Ok(_menuTableDal.TotalMenuTableCount());
        }
    }

}
