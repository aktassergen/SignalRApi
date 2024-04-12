using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BL.Abstract;
using SignalR.DAL.Concrete;
using SignalR.Dto.ContantDto;
using SignalR.Dto.FeatureDto;
using SignalR.Dto.ProductDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }
		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("AccordingToCategoryGetProduct")]
        public IActionResult AccordingToCategoryGetProduct()
        {
            var context = new SignalRContext();
           var value = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
           {
               ProductDescription = y.ProductDescription,
               CategoryName = y.Category.CategoryName,
               ProductId = y.ProductId,
               ProductImageUrl = y.ProductImageUrl,
               ProductName = y.ProductName,
               ProductPrice = y.ProductPrice,
               ProductStatus = y.ProductStatus
           });
            return Ok(value.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                CategoryId = createProductDto.CategoryId,
               ProductDescription = createProductDto.ProductDescription,
               ProductName = createProductDto.ProductName,
               ProductImageUrl = createProductDto.ProductImageUrl,
               ProductPrice = createProductDto.ProductPrice,
               ProductStatus = createProductDto.ProductStatus
               
            });
            return Ok("Ürün bilgisi eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("ürün bilgisi silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
               ProductStatus = updateProductDto.ProductStatus,
               ProductDescription = updateProductDto.ProductDescription,
               ProductName = updateProductDto.ProductName,
               ProductImageUrl = updateProductDto.ProductImageUrl,
               ProductPrice = updateProductDto.ProductPrice,
               ProductId=updateProductDto.ProductId,
               CategoryId=updateProductDto.CategoryId,
            });
            return Ok("Ürün  güncellendi");
        }
       
    }
}
