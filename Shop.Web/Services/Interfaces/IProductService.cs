using Shop.Web.Models;

namespace Shop.Web.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductViewModel>> GetAll();
    Task<ProductViewModel> GetById(long id);
    Task<ProductViewModel> Create(ProductViewModel productViewModel);
    Task<ProductViewModel> Update(ProductViewModel productViewModel);
    Task<bool> Delete(long id);
}
