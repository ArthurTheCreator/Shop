using Arguments.Arguments.Base;
using Arguments.Arguments.Category;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.UnitOfWOrk;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    public CategoryController(IUnitOfWork unitOfWork, ICategoryService categoryService) : base(unitOfWork)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<OutputCategory>>> GetAll()
    {
        return await _categoryService.GetAll();
    }

    [HttpGet("Id")]
    public async Task<ActionResult<OutputCategory>> Get(InputIdentifyViewCategory inputIdentifyViewCategory)
    {
        return await _categoryService.Get(inputIdentifyViewCategory);
    }

    [HttpPost("GetByListId")]
    public async Task<ActionResult<List<OutputCategory>>> GetListByListId(List<InputIdentifyViewCategory> listInputIdentifyViewCategory)
    {
        return await _categoryService.GetListByListId(listInputIdentifyViewCategory);
    }

    [HttpGet("GetCategoryWithProducts")]
    public async Task<ActionResult<List<OutputCategory>>> GetCategoryWithProducts()
    {
        return await _categoryService.GetCategoriesWithProducts();
    }

    [HttpPost("Create")]
    public async Task<ActionResult<BaseResponse<OutputCategory>>> Create(InputCreateCategory InputCreateCategory)
    {
        var create = await _categoryService.Create(InputCreateCategory);
        if (!create.Success)
            return BadRequest(create);

        return Ok(create);
    }

    [HttpPost("CreateMultiple")]
    public async Task<ActionResult<BaseResponse<List<OutputCategory>>>> CreateMultiple(List<InputCreateCategory> listInputCreateCategory)
    {
        var create = await _categoryService.CreateMultiple(listInputCreateCategory);
        if (!create.Success)
            return BadRequest(create);

        return Ok(create);
    }

    [HttpPut]
    public async Task<ActionResult<BaseResponse<OutputCategory>>> Update(InputIdentifyUpdateCategory inputIdentifyUpdateCategory)
    {
        var update = await _categoryService.Update(inputIdentifyUpdateCategory);
        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }

    [HttpPut("UpdateMultiple")]
    public async Task<ActionResult<BaseResponse<OutputCategory>>> UpdateMultiple(List<InputIdentifyUpdateCategory>  listInputIdentifyUpdateCategory)
    {
        var update = await _categoryService.UpdateMultiple(listInputIdentifyUpdateCategory);
        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }

    [HttpDelete]
    public async Task<ActionResult<BaseResponse<List<OutputCategory>>>> Delete(InputIdentifyDeleteCategory InputIdentifyDeleteCategory)
    {
        var delete = await _categoryService.Delete(InputIdentifyDeleteCategory);
        if (!delete.Success)
            return BadRequest(delete);

        return Ok(delete);
    }

    [HttpDelete("DeleteMultiple")]
    public async Task<ActionResult<BaseResponse<List<OutputCategory>>>> DeleteMultiple(List<InputIdentifyDeleteCategory> listInputIdentifyDeleteCategory)
    {
        var delete = await _categoryService.DeleteMultiple(listInputIdentifyDeleteCategory);
        if (!delete.Success)
            return BadRequest(delete);

        return Ok(delete);
    }
}