using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _productService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int Id)
        {
            var value = _productService.TGetById(Id);
            return Ok(value);

        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateProductDto createProductDto)
        {
            Product product = new Product
            {
                ProductName = createProductDto.ProductName,
                Despcription = createProductDto.Despcription,
                Price = createProductDto.Price,
                ImageUrl = createProductDto.ImageUrl,
                ProductStatus = createProductDto.ProductStatus
            };
            _productService.TAdd(product);
            return Ok("Product Added Succesfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateProductDto updateProductDto)
        {
            Product product = new Product
            {
                ProductId = updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                Despcription = updateProductDto.Despcription,
                Price = updateProductDto.Price,
                ImageUrl = updateProductDto.ImageUrl,
                ProductStatus = updateProductDto.ProductStatus
            };
            _productService.TUpdate(product);
            return Ok("Product Updated Succesfully");
        }
        [HttpDelete("[action]")]
        public IActionResult Delete(int Id)
        {
            var value = _productService.TGetById(Id);
            _productService.TDelete(value);
            return Ok("Product Deleted Succesfully");

        }
    }
}
