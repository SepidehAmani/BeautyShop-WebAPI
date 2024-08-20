using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.Entities.User;
using BeautyShopDomain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyShopInfrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Username).IsRequired().HasMaxLength(15);
        builder.Property(x => x.MobileNumber).IsRequired().HasMaxLength(15);
        builder.Property(x => x.Password).IsRequired();

        builder.HasMany<UserSelectedRole>().WithOne().HasForeignKey(x => x.UserId);
        builder.HasMany<Order>().WithOne().HasForeignKey(x => x.UserId);

        builder.HasData(new User()
        {
            Id = -1,
            MobileNumber = "09141001010",
            Username = "Admin"
            ,
            Password = PasswordHasher.EncodePasswordMd5("qwe123")
        });
    }
}
