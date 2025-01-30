using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Interface.Repository;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task<List<TEntity>> GetAll();
    Task<TEntity> GetById(long id);
    Task<List<TEntity>> GetListByListId(List<long> listId);
    Task<List<TEntity?>> Create(List<TEntity>? listEntity);
    Task<bool> Update(List<TEntity> listEntity);
    Task<bool> Delete(List<TEntity> listEntity);
}