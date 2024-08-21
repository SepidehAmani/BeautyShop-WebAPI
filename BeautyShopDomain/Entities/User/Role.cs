using BeautyShopDomain.Entities.Base;

namespace BeautyShopDomain.Entities.User;

public class Role : BaseEntity, IEntity
{
    public string UniqueName { get; set; }
    public bool IsDelete { get; set; }


    public ICollection<UserSelectedRole>? UserSelectedRoles { get; set; }
}
