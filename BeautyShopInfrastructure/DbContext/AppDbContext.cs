using BeautyShopApplication.Utilities;
using BeautyShopDomain.Entities.ContactUs;
using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.Entities.Product;
using BeautyShopDomain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace BeautyShopInfrastructure.DBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Role>().HasData(new Role()
        {
            Id=-1,
            UniqueName = "Admin"
        });

        builder.Entity<Category>().HasData(
            [new Category() { Name = "آرایشی" , Id=-2 },
            new Category() { Name = "بهداشتی", Id=-1 },
            new Category() { Name = "زیردسته بندی آرایشی", Id = -4,ParentId=-2},
            new Category() {Name = "زیردسته بندی بهداشتی", Id = -3,ParentId=-1}
            ]);

        builder.Entity<UserSelectedRole>().HasData(new UserSelectedRole() 
        { Id = -1, RoleId = -1, UserId = -1, 
        });

        builder.Entity<User>().HasData(new User() 
        { Id = -1, MobileNumber = "09141001010", Username = "Admin"
            , Password = PasswordHasher.EncodePasswordMd5("qwe123") 
        });
    }

    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserSelectedRole> UserSelectedRoles { get; set; }
}
