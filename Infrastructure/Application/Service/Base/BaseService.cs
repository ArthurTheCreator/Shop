using Arguments.Arguments.Base;
using Arguments.Arguments.Base.DTO;
using AutoMapper;
using Infrastructure.Interface;
using Infrastructure.Interface.Repository;
using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Application.Service.Base;

public class BaseService<ITRepository, TEntity, TInputCreateDTO, TInputIdentityUpdateDTO, TInputIdentityDeleteDTO, TInputIdentityViewDTO, TOutuputDTO> : IBaseService<TEntity, TInputCreateDTO, TInputIdentityUpdateDTO, TInputIdentityDeleteDTO, TInputIdentityViewDTO, TOutuputDTO>
    where TEntity : BaseEntity, new()
    where TInputCreateDTO : BaseInputCreate<TInputCreateDTO>
    where TInputIdentityUpdateDTO : BaseInputIdentityUpdate<TInputIdentityUpdateDTO>
    where TInputIdentityDeleteDTO : BaseInputIdentityDelete<TInputIdentityDeleteDTO>
    where TInputIdentityViewDTO : BaseInputIdentityView<TInputIdentityViewDTO>, IHashId
    where TOutuputDTO : BaseOutuput<TOutuputDTO>
    where ITRepository : IRepository<TEntity>
{
    #region Dependency Injection
    private readonly ITRepository _repository;
    private readonly IMapper _mapper;

    public BaseService(ITRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    #endregion

    #region Get
    public async Task<List<TOutuputDTO>> GetAll()
    {
        var getAll = await _repository.GetAll();
        return _mapper.Map<List<TOutuputDTO>>(getAll);
    }

    public async Task<TOutuputDTO> Get(TInputIdentityViewDTO viewDTO)
    {
        var get = await _repository.GetById(viewDTO.Id);
        return _mapper.Map<TOutuputDTO>(get);
    }

    public async Task<List<TOutuputDTO>> GetListByListId(List<TInputIdentityViewDTO> listViewDTO)
    {
        var getList = await _repository.GetListByListId(listViewDTO.Select(i => i.Id).ToList());
        return _mapper.Map<List<TOutuputDTO>>(getList);
    }
    #endregion

    #region Create
    public virtual async Task<BaseResponse<TOutuputDTO>> Create(TInputCreateDTO createDTO)
    {
        throw new NotImplementedException();
    }

    public virtual Task<BaseResponse<List<TOutuputDTO>>> CreateMultiple(List<TInputCreateDTO> listCreateDTO)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Update
    public virtual Task<BaseResponse<bool>> Update(TInputIdentityUpdateDTO updateDTO)
    {
        throw new NotImplementedException();
    }

    public virtual Task<BaseResponse<bool>> UpdateMultiple(List<TInputIdentityUpdateDTO> listUpdateDTO)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Delete
    public virtual Task<BaseResponse<bool>> Delete(TInputIdentityDeleteDTO deleteDTO)
    {
        throw new NotImplementedException();
    }

    public virtual Task<BaseResponse<bool>> DeleteMultiple(List<TInputIdentityDeleteDTO> listdeleteDTO)
    {
        throw new NotImplementedException();
    }
    #endregion

}