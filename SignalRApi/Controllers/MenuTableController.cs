using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<MenuTable>>(_menuTableService.TGetAllList()));
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
                return Ok(_mapper.Map<MenuTable>(value));
            }
            return NotFound("Menu Table Not Found");
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateMenuTableDto createMenuTableDto)
        {
            var menuTable = _mapper.Map<MenuTable>(createMenuTableDto);
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
            var menuTable = _mapper.Map<MenuTable>(updateMenuTableDto);

            _menuTableService.TUpdate(menuTable);
            return Ok("Menu Table Updated Succesfuly");
        }
    }

}
