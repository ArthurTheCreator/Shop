using Infrastructure.Interface;
using Infrastructure.Interface.UnitOfWOrk;
using Infrastructure.Persistence.Entity.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BaseController<TService, TEntity, TCreateDTO, TUpdateDTO, TDeleteDTO, TViewDTO, TOutuputDTO> : Controller
    where TService : IService<TEntity, TCreateDTO, TUpdateDTO, TDeleteDTO, TViewDTO, TOutuputDTO>
    where TEntity : BaseEntity, new()
{
    #region Dependency Injaction
    protected readonly TService _service;
    protected readonly IUnitOfWork unitOfWork;

    public BaseController(TService service, IUnitOfWork unitOfWork)
    {
        _service = service;
        this.unitOfWork = unitOfWork;
    }
    #endregion

    #region Transaction
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        unitOfWork.BeginTransaction();
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        unitOfWork.Commit();
        base.OnActionExecuted(context);
    }
    #endregion

    #region Get
    [HttpGet]
    public async Task<ActionResult<List<TOutuputDTO>>> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost("Id")]
    public async Task<ActionResult<List<TOutuputDTO>>> Get(TViewDTO viewDTO)
    {
        return Ok(await _service.Get(viewDTO));
    }

    [HttpPost("GetByListId")]
    public async Task<ActionResult<List<TOutuputDTO>>> GetListByListId(List<TViewDTO> listViewDTO)
    {
        return Ok(await _service.GetListByListId(listViewDTO));
    }
    #endregion
}