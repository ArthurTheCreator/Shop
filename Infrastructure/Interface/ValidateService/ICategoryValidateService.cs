using Arguments.Arguments.Base;
using Arguments.Arguments.Category;

namespace Infrastructure.Interface.ValidateService;

public interface ICategoryValidateService
{
    BaseResponse<List<CategoryValidate>> Create(List<CategoryValidate> listCategoryValidate);
    BaseResponse<List<CategoryValidate>> Update(List<CategoryValidate> listCategoryValidate);
    BaseResponse<List<CategoryValidate>> Delete(List<CategoryValidate> listCategoryValidate);
}