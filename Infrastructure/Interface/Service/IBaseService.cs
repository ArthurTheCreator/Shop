using Arguments.Arguments.Base;
using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Interface;

public interface IBaseService<TEntity, TCreateDTO, TUpdateDTO, TDeleteDTO, TViewDTO, TOutuputDTO> where TEntity : BaseEntity, new()
{
    Task<List<TOutuputDTO>> GetAll();
    Task<TOutuputDTO> Get(TViewDTO viewDTO);
    Task<List<TOutuputDTO>> GetListByListId(List<TViewDTO> listViewDTO);
    Task<BaseResponse<TOutuputDTO>> Create(TCreateDTO createDTO);
    Task<BaseResponse<List<TOutuputDTO>>> CreateMultiple(List<TCreateDTO> listCreateDTO);
    Task<BaseResponse<bool>> Update(TUpdateDTO updateDTO);
    Task<BaseResponse<bool>> UpdateMultiple(List<TUpdateDTO> listUpdateDTO);
    Task<BaseResponse<bool>> Delete(TDeleteDTO deleteDTO);
    Task<BaseResponse<bool>> DeleteMultiple(List<TDeleteDTO> listdeleteDTO);
}