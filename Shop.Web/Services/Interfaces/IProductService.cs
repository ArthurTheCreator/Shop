using Shop.Web.Models;

namespace Shop.Web.Services.Interfaces;

public interface IProductService
{
    Task<List<OutputProduct>> GetAll();
    Task<OutputProduct> GetById(InputIdentityViewProduct inputIdentityViewProduct);
    Task<OutputProduct> Create(InputCreateProduct inputCreateProduct);
    Task<OutputProduct> Update(InputIdentityUpdateProduct inputIdentityUpdateProduct);
    Task<bool> Delete(InputIdentiityDeleteProduct inputIdentiityDeleteProduct);
}