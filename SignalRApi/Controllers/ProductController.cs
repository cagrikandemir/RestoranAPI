using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;


        public ProductController(IMapper mapper, IProductService productService, SignalRContext context)
        {
            _mapper = mapper;
            _productService = productService;
            _context = context;
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
        [HttpGet("[action]")]
        public IActionResult GetAllProductsWithCategory()
        {
                var values = _context.Products.Include(x => x.Category)
                .Select(y => new ResultProductWithCategory
        {
            ProductId = y.ProductId,
            ProductName = y.ProductName,
            Despcription = y.Despcription,
            Price = y.Price,
            ImageUrl = y.ImageUrl,
            ProductStatus = y.ProductStatus,
            CategoryName = y.Category.CategoryName
        }).ToList();

            return Ok(values);

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
