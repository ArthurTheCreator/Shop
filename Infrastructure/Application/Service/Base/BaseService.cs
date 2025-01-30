using Arguments.Arguments.Base;
using AutoMapper;
using Infrastructure.Interface;
using Infrastructure.Interface.Repository;
using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Application.Service.Base;

public class BaseService<TEntity, TCreateDTO, TUpdateDTO, TDeleteDTO, TViewDTO, TOutuputDTO> : IService<TEntity, TCreateDTO, TUpdateDTO, TDeleteDTO, TViewDTO, TOutuputDTO> where TEntity : BaseEntity, new() where TViewDTO : IHashId
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public BaseService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<TOutuputDTO>> GetAll()
    {
        var getAll = await _repository.GetAll();
        return _mapper.Map<List<TOutuputDTO>>(getAll);
    }

    public async Task<TOutuputDTO> Get(TViewDTO viewDTO)
    {
        var get = await _repository.GetById(viewDTO.Id);
        return _mapper.Map<TOutuputDTO>(get);
    }


    public async Task<List<TOutuputDTO>> GetListByListId(List<TViewDTO> listViewDTO)
    {
        var getList = await _repository.GetListByListId(listViewDTO.Select(i => i.Id).ToList());
        return _mapper.Map<List<TOutuputDTO>>(getList);
    }
}