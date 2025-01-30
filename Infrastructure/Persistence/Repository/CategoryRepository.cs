using Infrastructure.Interface.Repository;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly DbSet<Category> _dbSet;
    public CategoryRepository(AppDbContext context) : base(context)
    {
        _dbSet = context.Set<Category>();
    }

    public async Task<List<Category>> CategoriesWithProducts()
    {
        return await _dbSet.Include(i => i.listProduct).ToListAsync();
    }
}