using Arguments.Arguments.Base;
using Arguments.Arguments.Category;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Interface.Service
{
    public interface ICategoryService : IService<Category, InputCreateCategory, InputIdentifyUpdateCategory, InputIdentifyDeleteCategory, InputIdentifyViewCategory, OutputCategory>
    {
        Task<List<OutputCategory>> GetCategoriesWithProducts();
        Task<BaseResponse<OutputCategory>> Create(InputCreateCategory inputCreateCategory);
        Task<BaseResponse<List<OutputCategory>>> CreateMultiple(List<InputCreateCategory> listInputCreateCategory);
        Task<BaseResponse<bool>> Update(InputIdentifyUpdateCategory inputIdentifyUpdateCategory);
        Task<BaseResponse<bool>> UpdateMultiple(List<InputIdentifyUpdateCategory> listInputIdentifyUpdateCategory);
        Task<BaseResponse<bool>> Delete(InputIdentifyDeleteCategory inputIdentifyDeleteCategory);
        Task<BaseResponse<bool>> DeleteMultiple(List<InputIdentifyDeleteCategory> listInputIdentifyDeleteCategory);
    }
}