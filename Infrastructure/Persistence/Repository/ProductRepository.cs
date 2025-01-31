using Infrastructure.Interface.Repository;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly DbSet<Product> _dbSet;
    public ProductRepository(AppDbContext context) : base(context)
    {
        _dbSet = context.Products;
    }

    public Task<List<Product>> GetByListCategoryId(List<long> listCategoryId)
    {
        return _dbSet.Where(i => listCategoryId.Contains(i.CategoryId)).ToListAsync();
    }
}
