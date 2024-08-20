using BeautyShopDomain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.Entities.User;

public class UserSelectedRole : BaseEntity, IEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public bool IsDelete {  get; set; }


    public User? User { get; set; }
    public Role? Role { get; set; }
}
