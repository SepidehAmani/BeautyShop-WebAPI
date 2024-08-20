using BeautyShopDomain.Entities.Image;
using BeautyShopDomain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BeautyShopInfrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(15);
            builder.Property(x=> x.CategoryId).IsRequired();
            builder.Property(x=> x.Description).HasMaxLength(200);

            builder.HasMany<ProductItem>().WithOne().HasForeignKey(x => x.ProductId);
            builder.HasMany<ProductFeature>().WithOne().HasForeignKey(x => x.ProductId);
            builder.HasOne<Image>().WithOne().HasForeignKey<Product>(x => x.GeneralImageId);

            //builder.OwnsMany(a => a.ProductItems).ToJson();

            //builder.HasIndex(x => x.Price);

            builder.HasData([
            new Product(){Id=-4,CategoryId=-4,Description="",Name="Product4",Price=1000,DiscountPercentage=10 },
            new Product(){Id=-3,CategoryId=-3,Description="",Name="Product3",Price=1000,DiscountPercentage=10 },
            new Product(){Id=-2,CategoryId=-4,Description="",Name="Product2",Price=2000,DiscountPercentage=10 },
            new Product(){Id=-1,CategoryId=-3,Description="",Name="Product1",Price=2000,DiscountPercentage=10 }
                ]);
        }
    }
}
