using Infrastructure.Persistence.Entity;

namespace Infrastructure.Interface.Repository;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetByListCategoryId(List<long> listCategoryId);
}