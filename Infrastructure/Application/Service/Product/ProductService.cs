using Arguments.Arguments;
using Arguments.Arguments.Base;
using Arguments.Arguments.Product;
using AutoMapper;
using Infrastructure.Application.Service.Base;
using Infrastructure.Interface.Repository;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.ValidateService;
using Infrastructure.Persistence.Entity;
using System.Net.WebSockets;

namespace Infrastructure.Application;

public class ProductService : BaseService<Product, InputCreateProduct, InputIdentifyUpdateProduct, InputIdentifyDeleteProduct, InputIdentifyViewProduct, OutputProduct>, IProductService
{
    #region InjectionDependecy
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductValidateService _productValidateService;
    private readonly IMapper _mapper;
    public ProductService(IRepository<Product> repository, IMapper mapper, IProductRepository productRepository, ICategoryRepository categoryRepository, IProductValidateService productValidateService) : base(repository, mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _productValidateService = productValidateService;
    }
    #endregion

    #region Create
    public async Task<BaseResponse<OutputProduct>> Create(InputCreateProduct inputCreateProduct)
    {
        var response = new BaseResponse<OutputProduct>();
        var validate = await CreateMultiple([inputCreateProduct]);
        response.Success = validate.Success;
        response.Message = validate.Message;
        if (!response.Success)
            return response;

        response.Content = validate.Content.FirstOrDefault();
        return response;
    }
    public async Task<BaseResponse<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct)
    {
        var response = new BaseResponse<List<OutputProduct>>();
        var listCategory = (await _categoryRepository.GetListByListId(listInputCreateProduct.Select(i => i.CategoryId).ToList())).Select(j => j.Id).ToList();
        var listCreate = (from i in listInputCreateProduct
                          select new
                          {
                              InputCreateProduct = i,
                              CategoryId = listCategory.FirstOrDefault(j => j == i.CategoryId)
                          }).ToList();

        List<ProductValidate> listValidateProduct = listCreate.Select(i => new ProductValidate().Create(i.InputCreateProduct, i.CategoryId)).ToList();

        var validate = _productValidateService.Create(listValidateProduct);
        response.Success = validate.Success;
        response.Message = validate.Message;

        if (!response.Success)
            return response;

        var listCreateValidate = (from i in validate.Content
                                  let message = response.AddSuccessMessage($"O Produto de Nome: {i.InputCreateProduct.Name} foi cadastrado com sucesso.")
                                  select new Product(i.InputCreateProduct.Name, i.InputCreateProduct.Description, i.InputCreateProduct.Price, i.InputCreateProduct.Stock, i.InputCreateProduct.CategoryId, i.InputCreateProduct.ImageURL)).ToList();

        var create = await _productRepository.Create(listCreateValidate);

        response.Content = _mapper.Map<List<OutputProduct>>(create);
        return response;
    }
    #endregion

    #region Update
    public async Task<BaseResponse<bool>> Update(InputIdentifyUpdateProduct inputIdentifyUpdateProduct)
    {
        return await UpdateMultiple([inputIdentifyUpdateProduct]);
    }

    public async Task<BaseResponse<bool>> UpdateMultiple(List<InputIdentifyUpdateProduct> listInputIdentifyUpdateProduct)
    {
        var response = new BaseResponse<bool>();
        var listIdentify = listInputIdentifyUpdateProduct.Select(i => i.Id).ToList();
        var listCategoryId = (await _categoryRepository.GetListByListId(listIdentify)).Select(i => i.Id).ToList();
        var listRepeteIdentify = (from i in listIdentify
                                  where listIdentify.Count(j => j == i) > 1
                                  select i).ToList();
        var listOriginalProductDTO = await _productRepository.GetListByListId(listIdentify);
        var listUpdate = (from i in listInputIdentifyUpdateProduct
                          select new
                          {
                              InputIdentifyUpdateProduct = i,
                              OriginalProductDTO = listOriginalProductDTO.FirstOrDefault(j => j.Id == i.Id),
                              CategoryId = listCategoryId.FirstOrDefault(k => k == i.InputUpdateProduct.CategoryId),
                              RepeteIdentify = listRepeteIdentify.FirstOrDefault(l => l == i.Id)
                          }).ToList();

        List<ProductValidate> listProductValidates = listUpdate.Select(i => new ProductValidate().Update(i.InputIdentifyUpdateProduct, _mapper.Map<ProductDTO>(i.OriginalProductDTO), i.CategoryId, i.RepeteIdentify)).ToList();
        var validate = _productValidateService.Update(listProductValidates);
        response.Success = validate.Success;
        response.Message = validate.Message;
        if (!response.Success)
            return response;

        var listUpdateProducts = (from i in validate.Content
                                  let name = i.ProductDTO.Name = i.InputCreateProduct.Name
                                  let deescription = i.ProductDTO.Description = i.InputCreateProduct.Description
                                  let price = i.ProductDTO.Price = i.InputCreateProduct.Price
                                  let stock = i.ProductDTO.Stock = i.InputCreateProduct.Stock
                                  let categoryId = i.ProductDTO.CategoryId = i.InputCreateProduct.CategoryId
                                  let imgageURL = i.ProductDTO.ImageURL = i.InputCreateProduct.ImageURL
                                  let message = response.AddSuccessMessage("")
                                  select i.ProductDTO).ToList();

        response.Content = await _productRepository.Update(_mapper.Map<List<Product>>(listUpdateProducts));
        return response;
    }
    #endregion

    #region Delete

    public Task<BaseResponse<bool>> Delete(InputIdentifyDeleteProduct inputIdentifyDeleteProduct)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> DeleteMultiple(List<InputIdentifyDeleteProduct> listInputIdentifyDeleteProduct)
    {
        throw new NotImplementedException();
    }
    #endregion
}
