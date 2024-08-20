using BeautyShopDomain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyShopInfrastructure.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UniqueName).IsRequired();

        builder.HasMany<UserSelectedRole>().WithOne().HasForeignKey(x => x.RoleId);

        builder.HasData(new Role()
        {
            Id = -1,
            UniqueName = "Admin"
        });
    }
}
