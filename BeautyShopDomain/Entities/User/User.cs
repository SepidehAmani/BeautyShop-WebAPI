using BeautyShopDomain.Entities.Base;
using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.Utilities;

namespace BeautyShopDomain.Entities.User
{
    public class User : BaseEntity, IEntity
    {
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public bool IsDelete { get; set; }


        public ICollection<UserSelectedRole>? UserSelectedRoles { get; set; }
        public ICollection<Order.Order>? Orders { get; set; }

    }
}
