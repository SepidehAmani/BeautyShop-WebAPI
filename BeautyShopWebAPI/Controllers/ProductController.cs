using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BeautyShopWebAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("{productId:int}")]
        public async Task<ActionResult> GetProduct(int productId, CancellationToken cancellation = default)
        {
            var model = await _productService.GetProductPageDTO(productId, cancellation);
            if(model==null) return NotFound("There is no product with this Id");
            return Ok(model);
        }


        [HttpGet("ProductList/{searchString?}")]
        public async Task<ActionResult> GetListOfProducts(string? searchString,ProductListRequestDTO requestDTO,
            CancellationToken cancellation=default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var model = await _productService.GetListOfProductDTOs(searchString,requestDTO, cancellation);
            return Ok(model);
        }
    }
}
