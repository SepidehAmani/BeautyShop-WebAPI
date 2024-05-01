﻿using BeautyShopDomain.DTOs;
using BeautyShopDomain.Entities.Product;

namespace BeautyShopDomain.RepositoryInterfaces;

public interface IProductRepository
{
    Task<Product?> GetProductById(int id, CancellationToken cancellation);
    Task<ICollection<ProductBoxDTO>?> GetProductBoxDTOsByCategoryIds(List<int> categoryIds, CategoryPageRequestDTO requestDTO, CancellationToken cancellation);
}
