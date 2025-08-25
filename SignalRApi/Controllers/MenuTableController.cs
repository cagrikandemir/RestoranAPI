using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_menuTableService.TGetAllList());
        }
        [HttpGet("[action]")]
        public IActionResult GetTotalMenuTableCount()
        {
            return Ok(_menuTableService.TTotalMenuTableCount());
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetById(int id)
        {
            var value = _menuTableService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return NotFound("Menu Table Not Found");
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new()
            {
                Name = createMenuTableDto.Name,
                Status = createMenuTableDto.Status
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Menu Table Added Succesfuly");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult Remove(int id)
        {
            var value = _menuTableService.TGetById(id);
            if(value != null)
            {
                _menuTableService.TDelete(value);
                return Ok("Menu Table Removed Succesfuly");
            }
            return NotFound("Menu Table Not Found");
        }
        [HttpPut("[action]")]
        public IActionResult Update (UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new()
            {
                MenuTableId = updateMenuTableDto.MenuTableId,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Menu Table Updated Succesfuly");
        }
    }

}
