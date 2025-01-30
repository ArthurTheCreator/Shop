using Arguments.Arguments.Base;
using Arguments.Arguments.Product;

namespace Infrastructure.Interface.ValidateService;

public interface IProductValidateService
{
    BaseResponse<List<ProductValidate>> Create(List<ProductValidate> listProductValidate);
    BaseResponse<List<ProductValidate>> Update(List<ProductValidate> listProductValidate);
    BaseResponse<List<ProductValidate>> Delete(List<ProductValidate> listProductValidate);
}