using Arguments.Arguments.Product;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.UnitOfWOrk;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    public ProductController(IUnitOfWork unitOfWork, IProductService productService) : base(unitOfWork)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<OutputProduct>>> GetAll()
    {
        return await _productService.GetAll();
    }

    [HttpGet("Id")]
    public async Task<ActionResult<OutputProduct>> Get(InputIdentifyViewProduct inputIdentifyViewProduct)
    {
        return await _productService.Get(inputIdentifyViewProduct);
    }

    [HttpPost("GetByListId")]
    public async Task<ActionResult<List<OutputProduct>>> GetListByListId(List<InputIdentifyViewProduct> listInputIdentifyViewProduct)
    {
        return await _productService.GetListByListId(listInputIdentifyViewProduct);
    }

    [HttpPost]
    public async Task<ActionResult<OutputProduct>> Create(InputCreateProduct inputCreateProduct)
    {
        var create = await _productService.Create(inputCreateProduct);
        if (!create.Success)
            return BadRequest(create);

        return Ok(create);
    }

    [HttpPost("CreateMultiple")]
    public async Task<ActionResult<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct)
    {
        var create = await _productService.CreateMultiple(listInputCreateProduct);
        if (!create.Success)
            return BadRequest(create);

        return Ok(create);
    }
}