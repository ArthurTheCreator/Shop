using Arguments.Arguments.Base;
using Arguments.Arguments.Product;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.UnitOfWOrk;
using Infrastructure.Persistence.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ProductController : BaseController<IProductService, Product, InputCreateProduct, InputIdentityUpdateProduct, InputIdentiityDeleteProduct, InputIdentityViewProduct, OutputProduct>
{
    private readonly IProductService _productService;
    public ProductController(IUnitOfWork unitOfWork, IProductService productService, IProductService _productService) : base(productService, unitOfWork)
    {
        this._productService = _productService;
    }

    [HttpPost("Create")]
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

    [HttpPut("Update")]
    public async Task<ActionResult<BaseResponse<bool>>> Update(InputIdentityUpdateProduct inputIdentifyUpdateProduct)
    {
        var update = await _productService.Update(inputIdentifyUpdateProduct);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }

    [HttpPut("UpdateMultiple")]
    public async Task<ActionResult<BaseResponse<bool>>> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentifyUpdateProduct)
    {
        var update = await _productService.UpdateMultiple(listInputIdentifyUpdateProduct);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(InputIdentiityDeleteProduct inputIdentifyDeleteProduct)
    {
        var update = await _productService.Delete(inputIdentifyDeleteProduct);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }

    [HttpDelete("DeleteMultiple")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteMultiple(List<InputIdentiityDeleteProduct> listInputIdentifyDeleteProduct)
    {
        var update = await _productService.DeleteMultiple(listInputIdentifyDeleteProduct);

        if (!update.Success)
            return BadRequest(update);

        return Ok(update);
    }
}