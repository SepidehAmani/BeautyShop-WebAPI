namespace BeautyShopDomain.DTOs.AdminSide;

public class UserDTO
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string Username { get; set; }
    public string MobileNumber { get; set; }
    public ICollection<string>? Roles { get; set; }
}
