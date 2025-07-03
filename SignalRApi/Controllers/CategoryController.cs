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

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _categoryService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int Id)
        {
            var value = _categoryService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                CategoryStatus = createCategoryDto.CategoryStatus
            };
            _categoryService.TAdd(category);
            return Ok("Category Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateCategoryDto updateCategoryDto)
        {
            Category category = new Category
            {
                CategoryId = updateCategoryDto.CategoryId,
                CategoryName = updateCategoryDto.CategoryName,
                CategoryStatus = updateCategoryDto.CategoryStatus
            };
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
