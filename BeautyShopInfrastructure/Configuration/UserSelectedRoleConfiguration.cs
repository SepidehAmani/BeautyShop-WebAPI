using BeautyShopDomain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyShopInfrastructure.Configuration;

public class UserSelectedRoleConfiguration : IEntityTypeConfiguration<UserSelectedRole>
{
    public void Configure(EntityTypeBuilder<UserSelectedRole> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.RoleId).IsRequired();
        builder.Property(x => x.UserId).IsRequired();

        builder.HasData(new UserSelectedRole()
        {
            Id = -1,
            RoleId = -1,
            UserId = -1,
        });
    }
}
