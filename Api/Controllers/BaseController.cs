﻿using Arguments.Arguments.Base;
using Arguments.Arguments.Base.DTO;
using Arguments.Arguments.Product;
using Infrastructure.Interface;
using Infrastructure.Interface.UnitOfWOrk;
using Infrastructure.Persistence.Entity.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BaseController<TService, TEntity, TInputCreateDTO, TInputIdentityUpdateDTO, TInputIdentityDeleteDTO, TInputIdentityViewDTO, TOutuputDTO> : Controller
    where TService : IBaseService<TEntity, TInputCreateDTO, TInputIdentityUpdateDTO, TInputIdentityDeleteDTO, TInputIdentityViewDTO, TOutuputDTO>
    where TEntity : BaseEntity, new()
    where TInputCreateDTO : BaseInputCreate<TInputCreateDTO>
    where TInputIdentityUpdateDTO : BaseInputIdentityUpdate<TInputIdentityUpdateDTO>
    where TInputIdentityDeleteDTO : BaseInputIdentityDelete<TInputIdentityDeleteDTO>
    where TInputIdentityViewDTO : BaseInputIdentityView<TInputIdentityViewDTO>, IHashId
    where TOutuputDTO : BaseOutuput<TOutuputDTO>
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
    public async Task<ActionResult<List<TOutuputDTO>>> Get(TInputIdentityViewDTO viewDTO)
    {
        return Ok(await _service.Get(viewDTO));
    }

    [HttpPost("GetByListId")]
    public async Task<ActionResult<List<TOutuputDTO>>> GetListByListId(List<TInputIdentityViewDTO> listViewDTO)
    {
        return Ok(await _service.GetListByListId(listViewDTO));
    }
    #endregion

    #region Create
    [HttpPost("Create")]
    public async Task<ActionResult<TOutuputDTO>> Create(TInputCreateDTO createDTO)
    {
        var create = await _service.Create(createDTO);
        if (!create.Success)
            return BadRequest(create);

        return Ok(create);
    }

    [HttpPost("CreateMultiple")]
    public async Task<ActionResult<List<OutputProduct>>> CreateMultiple(List<TInputCreateDTO> listCreateDTO)
    {
        var create = await _service.CreateMultiple(listCreateDTO);
        if (!create.Success)
            return BadRequest(create);

        return Ok(create);
    }
    #endregion

    #region Update
    [HttpPut("Update")]
    public async Task<ActionResult<BaseResponse<bool>>> Update(TInputIdentityUpdateDTO UpdateDTO)
    {
        var update = await _service.Update(UpdateDTO);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }

    [HttpPut("UpdateMultiple")]
    public async Task<ActionResult<BaseResponse<bool>>> UpdateMultiple(List<TInputIdentityUpdateDTO> listUpdateDTO)
    {
        var update = await _service.UpdateMultiple(listUpdateDTO);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }
    #endregion

    #region Delete
    [HttpDelete("Delete")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(TInputIdentityDeleteDTO deleteDTO)
    {
        var update = await _service.Delete(deleteDTO);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }

    [HttpDelete("DeleteMultiple")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteMultiple(List<TInputIdentityDeleteDTO> listdeleteDTO)
    {
        var update = await _service.DeleteMultiple(listdeleteDTO);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }
    #endregion

}