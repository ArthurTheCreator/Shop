using Arguments.Arguments.Base;
using Arguments.Arguments.Base.DTO;
using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Interface;

public interface IBaseService<TEntity, TInputCreateDTO, TInputIdentityUpdateDTO, TInputIdentityDeleteDTO, TInputIdentityViewDTO, TOutuputDTO> 
    where TEntity : BaseEntity, new()
    where TInputCreateDTO : BaseInputCreate<TInputCreateDTO>
    where TInputIdentityUpdateDTO : BaseInputIdentityUpdate<TInputIdentityUpdateDTO>
    where TInputIdentityDeleteDTO : BaseInputIdentityDelete<TInputIdentityDeleteDTO>
    where TInputIdentityViewDTO : BaseInputIdentityView<TInputIdentityViewDTO>, IHashId
    where TOutuputDTO : BaseOutuput<TOutuputDTO>
{
    Task<List<TOutuputDTO>> GetAll();
    Task<TOutuputDTO> Get(TInputIdentityViewDTO viewDTO);
    Task<List<TOutuputDTO>> GetListByListId(List<TInputIdentityViewDTO> listViewDTO);
    Task<BaseResponse<TOutuputDTO>> Create(TInputCreateDTO createDTO);
    Task<BaseResponse<List<TOutuputDTO>>> CreateMultiple(List<TInputCreateDTO> listCreateDTO);
    Task<BaseResponse<bool>> Update(TInputIdentityUpdateDTO updateDTO);
    Task<BaseResponse<bool>> UpdateMultiple(List<TInputIdentityUpdateDTO> listUpdateDTO);
    Task<BaseResponse<bool>> Delete(TInputIdentityDeleteDTO deleteDTO);
    Task<BaseResponse<bool>> DeleteMultiple(List<TInputIdentityDeleteDTO> listdeleteDTO);
}