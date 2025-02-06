using Shop.Web.Models;
using Shop.Web.Services.Interfaces;
using System.Text.Json;

namespace Shop.Web.Services.Service;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string apiEndpoint = "/api/v1/Product";
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private List<OutputProduct> listOutputProduct;
    private OutputProduct outputProduct;
    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<OutputProduct>> GetAll()
    {
        var getAll = _httpClientFactory.CreateClient("ProducrApi");
        using (var response = await getAll.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                listOutputProduct = await JsonSerializer
                                        .DeserializeAsync<List<OutputProduct>>(apiResponse, _jsonSerializerOptions);
            }
            else return null;
        }
        return listOutputProduct;
    }

    public Task<ProductViewModel> GetById(InputIdentityViewProduct inputIdentityViewProduct)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> Create(InputCreateProduct inputCreateProduct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(InputIdentiityDeleteProduct inputIdentiityDeleteProduct)
    {
        throw new NotImplementedException();
    }


    public Task<ProductViewModel> Update(InputIdentityUpdateProduct inputIdentityUpdateProduct)
    {
        throw new NotImplementedException();
    }
}
