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
            return Ok(_mapper.Map<List<Product>>(_productService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Product>(_productService.TGetById(Id)));

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

            return Ok(values.ToList());

        }
        [HttpGet("[action]")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.TProductCount());
        }
        [HttpGet("[action]")]
        public IActionResult GetProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("[action]")]
        public IActionResult GetProductCountByCategoryNameDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }
        [HttpGet("[action]")]
        public IActionResult GetProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }
        [HttpGet("[action]")]
        public IActionResult GetProductPriceByMax()
        {
            return Ok(_productService.TProductPriceByMax());
        }
        [HttpGet("[action]")]
        public IActionResult GetProductPriceByMin()
        {
            return Ok(_productService.TProductPriceByMin());
        }
        [HttpGet("[action]")]
        public IActionResult GetProductAvgPriceByHamburger()
        {
            return Ok(_productService.TProductAvgPriceByHamburger());
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok("Product Added Succesfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);

            _productService.TUpdate(product);
            return Ok("Product Updated Succesfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _productService.TGetById(Id);
            _productService.TDelete(value);
            return Ok("Product Deleted Succesfully");

        }
    }
}
