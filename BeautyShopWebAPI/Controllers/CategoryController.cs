﻿using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("{categoryId}")]
        public async Task<ActionResult> GetProductsForCategoryPage(int categoryId,CategoryPageRequestDTO requestDTO,CancellationToken cancellation=default)
        {
            var model = await _categoryService.GetProductDTOsByCategoryId(categoryId, requestDTO, cancellation);
            if (model == null) return NotFound();
            return Ok(model);
        }
    }
}
