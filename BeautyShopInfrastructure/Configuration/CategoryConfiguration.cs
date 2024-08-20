using BeautyShopDomain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyShopInfrastructure.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        builder.HasMany<Product>().WithOne().HasForeignKey(x => x.CategoryId);

        builder.HasData(
            [new Category() { Name = "آرایشی" , Id=-2 },
            new Category() { Name = "بهداشتی", Id=-1 },
            new Category() { Name = "زیردسته بندی آرایشی", Id = -4,ParentId=-2},
            new Category() {Name = "زیردسته بندی بهداشتی", Id = -3,ParentId=-1}
            ]);
    }
}
