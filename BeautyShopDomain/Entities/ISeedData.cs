namespace BeautyShopDomain.Entities;

public interface ISeedData<T>
{
    IEnumerable<T> GetSeedData();
}
