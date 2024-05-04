using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs;

public class AddToShopCardDTO
{
    [Required]
    public int ProductItemId { get; set; }
    [Required]
    public int Quantity { get; set; }
}
