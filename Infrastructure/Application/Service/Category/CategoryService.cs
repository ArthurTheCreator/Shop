using Arguments.Arguments.Base;
using Arguments.Arguments.Category;
using AutoMapper;
using Infrastructure.Application.Service.Base;
using Infrastructure.Interface.Repository;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.ValidateService;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Application;

public class CategoryService : BaseService<ICategoryRepository, Category, InputCreateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory, InputIdentityViewCategory, OutputCategory>, ICategoryService
{

    #region InjectionDependency

    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryValidateService _categoryValidateService;
    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository, ICategoryValidateService categoryValidateService, ICategoryRepository _categoryRepository, IProductRepository productRepository) : base(categoryRepository, mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._categoryRepository = _categoryRepository;
        _categoryValidateService = categoryValidateService;
        _productRepository = productRepository;
    }
    #endregion

    #region Get
    public async Task<List<OutputCategory>> GetCategoriesWithProducts()
    {
        return _mapper.Map<List<OutputCategory>>(await _categoryRepository.CategoriesWithProducts());
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

    public async Task<BaseResponse<bool>> Update(InputIdentityUpdateCategory inputIdentityUpdateCategory)
    {
        return await UpdateMultiple([inputIdentityUpdateCategory]);
    }

    public async Task<BaseResponse<bool>> UpdateMultiple(List<InputIdentityUpdateCategory> listInputIdentityUpdateCategory)
    {
        var response = new BaseResponse<bool>();

        var listCategoryExists = await _categoryRepository.GetListByListId(listInputIdentityUpdateCategory.Select(i => i.Id).ToList());
        var listRepeteIdentity = (from i in listInputIdentityUpdateCategory
                                  where listInputIdentityUpdateCategory.Count(j => j.Id == i.Id) > 1
                                  select i.Id).ToList();
        var listUpdate = (from i in listInputIdentityUpdateCategory
                          select new
                          {
                              InputUpdateCategory = i,
                              CategoryExists = listCategoryExists.FirstOrDefault(j => j.Id == i.Id),
                              RepeteIdentity = listRepeteIdentity.FirstOrDefault(k => k == i.Id)
                          }).ToList();

        List<CategoryValidate> listValidateUpdate = listUpdate.Select(i => new CategoryValidate().Update(i.InputUpdateCategory, _mapper.Map<CategoryDTO>(i.CategoryExists), i.RepeteIdentity)).ToList();

        var validate = _categoryValidateService.Update(listValidateUpdate);
        response.Success = validate.Success;
        response.Message = validate.Message;

        if (!response.Success)
            return response;

        var update = (from i in validate.Content
                      where !i.Invalid
                      let name = i.CategoryDTO.Name = i.InputIdentityUpdateCategory.InputUpdateCategory.Name
                      let description = i.CategoryDTO.Description = i.InputIdentityUpdateCategory.InputUpdateCategory.Description
                      let message = response.AddSuccessMessage($"A Categoria com id: {i.CategoryDTO.Id} foi atualizada com sucesso.")
                      select i.CategoryDTO).ToList();

        response.Content = await _categoryRepository.Update(update.Select(i => _mapper.Map<Category>(i)).ToList());
        return response;
    }
    #endregion

    #region Delete
    public async Task<BaseResponse<bool>> Delete(InputIdentityDeleteCategory inputIdentityDeleteCategory)
    {
        return await DeleteMultiple([inputIdentityDeleteCategory]);
    }

    public async Task<BaseResponse<bool>> DeleteMultiple(List<InputIdentityDeleteCategory> listInputIdentityDeleteCategory)
    {
        var response = new BaseResponse<bool>();

        var listCategoryExists = await _categoryRepository.GetListByListId(listInputIdentityDeleteCategory.Select(i => i.Id).ToList());

        var listRepetedIdentity = (from i in listInputIdentityDeleteCategory
                                   where listInputIdentityDeleteCategory.Count(j => j.Id == i.Id) > 1
                                   select i.Id).ToList();

        var listHasProduct = (await _productRepository.GetByListCategoryId(listInputIdentityDeleteCategory.Select(i => i.Id).ToList())).Select(i => i.CategoryId);

        var listDelete = (from i in listInputIdentityDeleteCategory
                          select new
                          {
                              InputIdentityDeleteCategory = i,
                              CategoryExists = listCategoryExists.FirstOrDefault(j => j.Id == i.Id),
                              RepetedIdentity = listRepetedIdentity.FirstOrDefault(k => k == i.Id),
                              HasProduct = listHasProduct.FirstOrDefault(l => l == i.Id)
                          }).ToList();

        List<CategoryValidate> listValidateDelete = listDelete.Select(i => new CategoryValidate().Delete(i.InputIdentityDeleteCategory, _mapper.Map<CategoryDTO>(i.CategoryExists), i.RepetedIdentity, i.HasProduct)).ToList();

        var validate = _categoryValidateService.Delete(listValidateDelete);
        response.Success = validate.Success;
        response.Message = validate.Message;

        if (!response.Success)
            return response;

        var delete = (from i in validate.Content
                      let message = response.AddSuccessMessage($"Categoria com ID: {i.InputIdentityDeleteCategory.Id} foi excluída com sucesso.")
                      select i.CategoryDTO).ToList();

        response.Content = await _categoryRepository.Delete(delete.Select(i => _mapper.Map<Category>(i)).ToList());
        return response;

    }
    #endregion

}