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
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            var value = _categoryService.TGetById(Id);
            return Ok(value);
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
