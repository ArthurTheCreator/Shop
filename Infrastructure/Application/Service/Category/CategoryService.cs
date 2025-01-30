using Arguments.Arguments.Base;
using Arguments.Arguments.Category;
using AutoMapper;
using Infrastructure.Application.Service.Base;
using Infrastructure.Interface.Repository;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.ValidateService;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Application;

public class CategoryService : BaseService<Category, InputCreateCategory, InputIdentifyUpdateCategory, InputIdentifyDeleteCategory, InputIdentifyViewCategory, OutputCategory>, ICategoryService
{

    #region InjectionDependency

    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryValidateService _categoryValidateService;
    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository, ICategoryValidateService categoryValidateService) : base(repository, mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _categoryRepository = categoryRepository;
        _categoryValidateService = categoryValidateService;
    }
    #endregion

    #region Get
    public async Task<List<OutputCategory>> GetCategoriesWithProducts()
    {
        return _mapper.Map<List<OutputCategory>>(await  _categoryRepository.CategoriesWithProducts());
    }
    #endregion

    #region Create
    public async Task<BaseResponse<OutputCategory>> Create(InputCreateCategory inputCreateCategory)
    {
        var response = new BaseResponse<OutputCategory>();
        var create = await CreateMultiple([inputCreateCategory]);
        response.Success = create.Success;
        response.Message = create.Message;

        if (!response.Success)
            return response;

        response.Content = create.Content.FirstOrDefault();
        return response;
    }

    public async Task<BaseResponse<List<OutputCategory>>> CreateMultiple(List<InputCreateCategory> listInputCreateCategory)
    {
        var response = new BaseResponse<List<OutputCategory>>();
        List<CategoryValidate> listCategoryValidate = listInputCreateCategory.Select(i => new CategoryValidate().Create(i)).ToList();
        var validate = _categoryValidateService.Create(listCategoryValidate);
        response.Success = validate.Success;
        response.Message = validate.Message;

        if (!response.Success)
            return response;

        var listCreate = (from i in validate.Content
                          let message = response.AddSuccessMessage($"A Categoria {i.InputCreateCategory.Name} foi cadastrada com sucesso!")
                          select new Category(i.InputCreateCategory.Name, i.InputCreateCategory.Description)).ToList();

        await _categoryRepository.Create(listCreate);
        response.Content = listCreate.Select(i => _mapper.Map<OutputCategory>(i)).ToList();
        return response;
    }
    #endregion

    #region Update

    public async Task<BaseResponse<bool>> Update(InputIdentifyUpdateCategory inputIdentifyUpdateCategory)
    {
        return await UpdateMultiple([inputIdentifyUpdateCategory]);
    }

    public async Task<BaseResponse<bool>> UpdateMultiple(List<InputIdentifyUpdateCategory> listInputIdentifyUpdateCategory)
    {
        var response = new BaseResponse<bool>();

        var listCategoryExists = await _categoryRepository.GetListByListId(listInputIdentifyUpdateCategory.Select(i => i.Id).ToList());
        var listRepeteIdentify = (from i in listInputIdentifyUpdateCategory
                                  where listInputIdentifyUpdateCategory.Count(j => j.Id == i.Id) > 1
                                  select i.Id).ToList();
        var listUpdate = (from i in listInputIdentifyUpdateCategory
                          select new
                          {
                              InputUpdateCategory = i,
                              CategoryExists = listCategoryExists.FirstOrDefault(j => j.Id == i.Id),
                              RepeteIdentify = listRepeteIdentify.FirstOrDefault(k => k == i.Id)
                          }).ToList();

        List<CategoryValidate> listValidateUpdate = listUpdate.Select(i => new CategoryValidate().Update(i.InputUpdateCategory, _mapper.Map<CategoryDTO>(i.CategoryExists), i.RepeteIdentify)).ToList();

        var validate = _categoryValidateService.Update(listValidateUpdate);
        response.Success = validate.Success;
        response.Message = validate.Message;

        if (!response.Success)
            return response;

        var update = (from i in validate.Content
                      where !i.Invalid
                      let name = i.CategoryDTO.Name = i.InputIdentifyUpdateCategory.InputUpdateCategory.Name
                      let description = i.CategoryDTO.Description = i.InputIdentifyUpdateCategory.InputUpdateCategory.Description
                      let message = response.AddSuccessMessage($"A Categoria com id: {i.CategoryDTO.Id} foi atualizada com sucesso.")
                      select i.CategoryDTO).ToList();

        response.Content = await _categoryRepository.Update(update.Select(i => _mapper.Map<Category>(i)).ToList());
        return response;
    }
    #endregion

    #region Delete
    public async Task<BaseResponse<bool>> Delete(InputIdentifyDeleteCategory inputIdentifyDeleteCategory)
    {
        return await DeleteMultiple([inputIdentifyDeleteCategory]);
    }

    public async Task<BaseResponse<bool>> DeleteMultiple(List<InputIdentifyDeleteCategory> listInputIdentifyDeleteCategory)
    {
        var response = new BaseResponse<bool>();

        var listCategoryExists = await _categoryRepository.GetListByListId(listInputIdentifyDeleteCategory.Select(i => i.Id).ToList());

        var listRepetedIdentify = (from i in listInputIdentifyDeleteCategory
                                   where listInputIdentifyDeleteCategory.Count(j => j.Id == i.Id) > 1
                                   select i.Id).ToList();

        var listDelete = (from i in listInputIdentifyDeleteCategory
                          select new
                          {
                              InputIdentifyDeleteCategory = i,
                              CategoryExists = listCategoryExists.FirstOrDefault(j => j.Id == i.Id),
                              RepetedIdentify = listRepetedIdentify.FirstOrDefault(k => k == i.Id)
                          }).ToList();

        List<CategoryValidate> listValidateDelete = listDelete.Select(i => new CategoryValidate().Delete(i.InputIdentifyDeleteCategory, _mapper.Map<CategoryDTO>(i.CategoryExists), i.RepetedIdentify)).ToList();

        var validate = _categoryValidateService.Delete(listValidateDelete);
        response.Success = validate.Success;
        response.Message = validate.Message;

        if (!response.Success)
            return response;

        var delete = (validate.Content.Select(i => i.CategoryDTO).ToList());
        response.Content = await _categoryRepository.Delete(delete.Select(i => _mapper.Map<Category>(i)).ToList());
        return response;

    }
    #endregion

}