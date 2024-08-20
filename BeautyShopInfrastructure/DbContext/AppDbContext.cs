using BeautyShopDomain.Entities;
using BeautyShopDomain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace BeautyShopInfrastructure.DBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    public DbSet<DiscountedProductViewModel> DiscountedProducts { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        RegisterEntities(builder);

        builder.Entity<DiscountedProductViewModel>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("DiscountedProducts");
        });
    }

    private void RegisterEntities(ModelBuilder builder)
    {
        var entityAssembly = Assembly.Load(nameof(BeautyShopDomain));

        var entityTypes = entityAssembly.GetTypes()
            .Where(t => typeof(IEntity).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

        foreach (var entityType in entityTypes)
        {
            if (builder.Model.FindEntityType(entityType) == null)
            {
                builder.Model.AddEntityType(entityType);
            }
        }
    }
}
