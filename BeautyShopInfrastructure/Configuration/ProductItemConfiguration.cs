using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyShopInfrastructure.Configuration;

public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();

        builder.HasMany<OrderItem>().WithOne().HasForeignKey(x => x.ProductItemId);


    }
}
