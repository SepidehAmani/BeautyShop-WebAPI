namespace BeautyShopDomain.Exceptions;

public class UserMobileDuplicateException : Exception
{
    public UserMobileDuplicateException(string? message) : base(message)
    {
    }
}
