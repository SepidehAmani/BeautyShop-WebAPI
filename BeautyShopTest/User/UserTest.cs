using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = BeautyShopDomain.Entities.User.User;

namespace BeautyShopTest.User
{
    public class UserTest
    {


      
        [InlineData("09144444444")]
        public void UserConstructor_SetMobileNo(string mobileNo)
        {

            var user = new BeautyShopDomain.Entities.User.User(mobileNo);

            Assert.Equal(user.MobileNo, mobileNo);
            
        }

        [InlineData("09144444444")]
        public void UserConstructor_SetMobileNo(string mobileNo)
        {

            var user = new BeautyShopDomain.Entities.User.User(mobileNo);

            Assert.Equal(user.MobileNo, mobileNo);

        }
    }
}
