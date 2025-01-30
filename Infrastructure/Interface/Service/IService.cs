using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Interface;

public interface IService<TEntity, TCreateDTO, TUpdateDTO, TDeleteDTO, TViewDTO, TOutuputDTO> where TEntity : BaseEntity, new()
{
    Task<List<TOutuputDTO>> GetAll();
    Task<TOutuputDTO> Get(TViewDTO viewDTO);
    Task<List<TOutuputDTO>> GetListByListId(List<TViewDTO> listViewDTO);
}