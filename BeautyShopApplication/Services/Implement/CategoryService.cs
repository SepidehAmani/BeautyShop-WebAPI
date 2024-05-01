using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.RepositoryInterfaces;

namespace BeautyShopApplication.Services.Implement;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    public CategoryService(ICategoryRepository categoryRepository,IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }


    public async Task<ICollection<ProductBoxDTO>?> GetProductDTOsByCategoryId(int categoryId,
        CategoryPageRequestDTO requestDTO,CancellationToken cancellation)
    {
        var category = await _categoryRepository.GetCategoryById(categoryId, cancellation);
        if (category == null) return null;

        List<int> categoryIdsToSearch = new List<int>();
        if (category.ParentId ==null)
        {
            var childCategories = await _categoryRepository.GetChildCategoriesByParentId(categoryId, cancellation);
            if (childCategories == null) return null;

            foreach (var childCategory in childCategories)
            {
                categoryIdsToSearch.Add(childCategory.Id);
            }
        }
        else
        {
            categoryIdsToSearch.Add(categoryId);
        }

        return await _productRepository.GetProductBoxDTOsByCategoryIds(categoryIdsToSearch, requestDTO, cancellation);
    }
}
