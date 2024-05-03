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


        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromForm] CreateProductDTO createProductDTO,CancellationToken cancellation=default)
        {
            if(createProductDTO.ImageDTO != null) 
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
    }
}
