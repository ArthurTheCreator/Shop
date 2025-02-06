using Infrastructure.Interface.Repository;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity?>();
    }


    public virtual async Task<List<TEntity>> GetAll()
    {
        return await _dbSet.AsNoTracking().ToListAsync(); // Usar o AsNoTracking -> pois está apenas lendo os dados, não vai modificar => ele reduz o uso de memória e processamento
    }

    public virtual async Task<TEntity> GetById(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<TEntity>> GetListByListId(List<long> listId)
    {
        return await _dbSet.AsNoTracking()
            .Where(x => listId.Contains(x.Id)).ToListAsync();
    }

    public async Task<List<TEntity?>> Create(List<TEntity> listEntity)
    {
        _dbSet.AddRange(listEntity);
        await _context.SaveChangesAsync();
        return listEntity;
    }
    public async Task<bool> Update(List<TEntity> listEntity)
    {
        _dbSet.UpdateRange(listEntity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(List<TEntity> listEntity)
    {
        _dbSet.RemoveRange(listEntity);
        await _context.SaveChangesAsync();
        return true;
    }
}