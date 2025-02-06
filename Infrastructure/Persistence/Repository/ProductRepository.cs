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

    public override async Task<List<Product>> GetAll()
    {
        return await _dbSet.Include(i => i.Category).AsNoTracking().ToListAsync(); // Usar o AsNoTracking -> pois está apenas lendo os dados, não vai modificar => ele reduz o uso de memória e processamento
    }
}
