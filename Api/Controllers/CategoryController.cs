using Arguments.Arguments.Category;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.UnitOfWOrk;
using Infrastructure.Persistence.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class CategoryController : BaseController<ICategoryService, Category, InputCreateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory, InputIdentityViewCategory, OutputCategory>
{
    private readonly ICategoryService _categoryService;

    public CategoryController(IUnitOfWork unitOfWork, ICategoryService categoryService, ICategoryService _categoryService) : base(categoryService, unitOfWork)
    {
        this._categoryService = _categoryService;
    }

    [HttpGet("GetCategoryWithProducts")]
    public async Task<ActionResult<List<OutputCategory>>> GetCategoryWithProducts()
    {
        return await _categoryService.GetCategoriesWithProducts();
    }
}