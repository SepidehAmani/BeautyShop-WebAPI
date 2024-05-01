namespace BeautyShopDomain.DTOs
{
    public record RegisterUserResponse(bool Successful,string Message);

    public record LoginUserResponse(bool Successful, string Token);

    public record EditRoleResponse(bool Successful, string Message);
}
