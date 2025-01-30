using Arguments.Arguments.Base;
using Arguments.Arguments.Product;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Interface.Service;

public interface IProductService : IService<Product, InputCreateProduct, InputIdentifyUpdateProduct, InputIdentifyDeleteProduct, InputIdentifyViewProduct, OutputProduct>
{
    Task<BaseResponse<OutputProduct>> Create(InputCreateProduct inputCreateProduct);
    Task<BaseResponse<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct);
    Task<BaseResponse<bool>> Update(InputIdentifyUpdateProduct inputIdentifyUpdateProduct);
    Task<BaseResponse<bool>> UpdateMultiple(List<InputIdentifyUpdateProduct> listInputIdentifyUpdateProduct);
    Task<BaseResponse<bool>> Delete(InputIdentifyDeleteProduct inputIdentifyDeleteProduct);
    Task<BaseResponse<bool>> DeleteMultiple(List<InputIdentifyDeleteProduct> listInputIdentifyDeleteProduct);
}