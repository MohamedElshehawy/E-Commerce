using E_Commerce.Api.Errors;
using E_Commerce.Api.Helper;
using E_Commerce.Core.DataTransferObjects;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Interfaces.Services;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Cash(60)]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecificationparameters specParamters)
            => Ok(await _productService.GetAllProductsAsync(specParamters));

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            throw new Exception();
            var product = await _productService.GetProductAsync(id);
            return product is not null ? Ok(product) : NotFound(new ApiResponse(404 , $"Product With Id {id} Not Found"));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandTypeDto>>> GetBrands()
            => Ok(await _productService.GetAllBrandsAsync());
        
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<BrandTypeDto>>> GetTypes()
            => Ok(await _productService.GetAllTypesAsync());
        
    }
}
