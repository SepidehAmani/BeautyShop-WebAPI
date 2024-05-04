using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs.AdminSide;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers.AdminSide
{
    [Route("api/Admin/Product")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("Create")]
        public async Task<ActionResult> CreateProduct([FromForm] CreateProductDTO createProductDTO,CancellationToken cancellation=default)
        {
            if(createProductDTO.ImageDTO != null && createProductDTO.ImageDTO.ImageFile != null) 
            {
                var imageValidation = _productService.ValidateImageFile(createProductDTO.ImageDTO);
                if (!imageValidation)
                {
                    ModelState.AddModelError("Image", "there is a problem with Image size or extension");
                }
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var model = await _productService.CreateProduct(createProductDTO, cancellation);
            if (model == null) return BadRequest();

            return Ok(model);
        }


        [HttpPost("{productId}/AddItem")]
        public async Task<ActionResult> CreateProductItem([FromForm] CreateProductItemDTO productItemDTO,int productId,CancellationToken cancellation=default)
        {
            if (productItemDTO.ImageDTO != null && productItemDTO.ImageDTO.ImageFile != null)
            {
                var imageValidation = _productService.ValidateImageFile(productItemDTO.ImageDTO);
                if (!imageValidation)
                {
                    ModelState.AddModelError("Image", "there is a problem with Image size or extension");
                }
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var model = await _productService.CreateProductItem(productItemDTO,productId, cancellation);
            if(model==null) return NotFound();

            return Ok(model);
        }


        [HttpPost("{productId}/AddFeature")]
        public async Task<ActionResult> CreateProductFeature(CreateProductFeatureDTO featureDTO,int productId,CancellationToken cancellation=default)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var model = await _productService.CreateProductFeature(featureDTO,productId, cancellation);
            if (model == null) return NotFound("There is no Product with this Id");

            return Ok(model);
        }
    }
}
