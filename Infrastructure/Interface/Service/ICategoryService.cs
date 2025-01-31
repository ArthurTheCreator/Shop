using Arguments.Arguments.Base;
using Arguments.Arguments.Category;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Interface.Service
{
    public interface ICategoryService : IService<Category, InputCreateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory, InputIdentityViewCategory, OutputCategory>
    {
        Task<List<OutputCategory>> GetCategoriesWithProducts();
        Task<BaseResponse<OutputCategory>> Create(InputCreateCategory inputCreateCategory);
        Task<BaseResponse<List<OutputCategory>>> CreateMultiple(List<InputCreateCategory> listInputCreateCategory);
        Task<BaseResponse<bool>> Update(InputIdentityUpdateCategory inputIdentifyUpdateCategory);
        Task<BaseResponse<bool>> UpdateMultiple(List<InputIdentityUpdateCategory> listInputIdentifyUpdateCategory);
        Task<BaseResponse<bool>> Delete(InputIdentityDeleteCategory inputIdentifyDeleteCategory);
        Task<BaseResponse<bool>> DeleteMultiple(List<InputIdentityDeleteCategory> listInputIdentifyDeleteCategory);
    }
}