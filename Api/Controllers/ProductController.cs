using Arguments.Arguments.Product;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.UnitOfWOrk;
using Infrastructure.Persistence.Entity;

namespace Api.Controllers;

public class ProductController(IUnitOfWork unitOfWork, IProductService productService) : BaseController<IProductService, Product, InputCreateProduct, InputIdentityUpdateProduct, InputIdentiityDeleteProduct, InputIdentityViewProduct, OutputProduct>(productService, unitOfWork)
{
}