namespace BeautyShopDomain.DTOs;

public class ProductListRequestDTO
{
    public string Order { get; set; } = "Newest";
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 12;
}
