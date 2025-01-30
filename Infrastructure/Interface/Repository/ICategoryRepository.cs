using Infrastructure.Persistence.Entity;

namespace Infrastructure.Interface.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    Task<List<Category>> CategoriesWithProducts();
}