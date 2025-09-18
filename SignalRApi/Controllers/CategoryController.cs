using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Category>>(_categoryService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Category>(_categoryService.TGetById(Id)));
        }
        [HttpGet("[action]")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }
        [HttpGet("[action]")]
        public IActionResult GetActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }
        [HttpGet("[action]")]
        public IActionResult GetPassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(category);
            return Ok("Category Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Category Updated Successfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _categoryService.TGetById(Id);
            _categoryService.TDelete(value);
            return Ok("Category Deleted Successfully");

        }
    }
}
