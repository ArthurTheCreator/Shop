using Infrastructure.Interface.Repository;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Persistence.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }
}
