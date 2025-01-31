using Arguments.Arguments.Base;
using Arguments.Arguments.Product;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Interface.Service;

public interface IProductService : IBaseService<Product, InputCreateProduct, InputIdentityUpdateProduct, InputIdentiityDeleteProduct, InputIdentityViewProduct, OutputProduct>
{
    Task<BaseResponse<OutputProduct>> Create(InputCreateProduct inputCreateProduct);
    Task<BaseResponse<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct);
    Task<BaseResponse<bool>> Update(InputIdentityUpdateProduct inputIdentifyUpdateProduct);
    Task<BaseResponse<bool>> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentifyUpdateProduct);
    Task<BaseResponse<bool>> Delete(InputIdentiityDeleteProduct inputIdentifyDeleteProduct);
    Task<BaseResponse<bool>> DeleteMultiple(List<InputIdentiityDeleteProduct> listInputIdentifyDeleteProduct);
}