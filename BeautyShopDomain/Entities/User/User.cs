using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.Base;
using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.Exceptions;
using BeautyShopDomain.RepositoryInterfaces;
using BeautyShopDomain.Utilities;

namespace BeautyShopDomain.Entities.User
{
    public class User : BaseEntity, IEntity
    {
        public User(string mobileNumber,string username , string password,IUserRepository userRepository)
        {
            SetMobile(mobileNumber, userRepository);

            Username = username;
            Password = PasswordHasher.EncodePasswordMd5(password);
            
        }

        public string Username { get; private set; }
        public string MobileNumber { get; private set; }
        public string Password { get; private set; }
        public bool IsDelete { get; set; }


        public void SetMobile(string mobileNumber, IUserRepository userRepository)
        {
            var mobileExists = userRepository.UserExistsWithThisMobile(mobileNumber);

            if (mobileExists) throw new UserMobileDuplicateException("There is another User having this Mobile number");

            MobileNumber = mobileNumber;
        }

        public ICollection<UserSelectedRole>? UserSelectedRoles { get; set; }
        public ICollection<Order.Order>? Orders { get; set; }

    }
}
