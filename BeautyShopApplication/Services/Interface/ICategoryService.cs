﻿using BeautyShopDomain.DependencyInjection;
using BeautyShopDomain.DTOs;

namespace BeautyShopApplication.Services.Interface;

public interface ICategoryService : IScopedDependency
{
    Task<ICollection<ProductBoxDTO>?> GetProductDTOsByCategoryId(int categoryId,
        CategoryPageRequestDTO requestDTO, CancellationToken cancellation);
    Task<ICollection<ParentCatgeoryDTO>?> GetListOfCategoryDTOs(CancellationToken cancellation);
}
