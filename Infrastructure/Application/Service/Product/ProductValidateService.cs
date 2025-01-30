using Arguments.Arguments.Base;
using Arguments.Arguments.Product;
using Infrastructure.Interface.ValidateService;

namespace Infrastructure.Application.Service.Product;

public class ProductValidateService : IProductValidateService
{
    public BaseResponse<List<ProductValidate>> Create(List<ProductValidate> listProductValidate)
    {
        var response = new BaseResponse<List<ProductValidate>>();

        _ = (from i in listProductValidate
             where i.CategoryId == 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputCreateProduct.Name} e o Id de Categoria: {i.InputCreateProduct.CategoryId}, não pode ser cadastrado pois não existe nenhuma categoria com esse id, verifique os dados.")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputCreateProduct.Price < 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputCreateProduct.Name} e preço: {i.InputCreateProduct.Price}, não pode ser cadastrado, pois o preço não pode ser negativo.")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputCreateProduct.Stock < 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputCreateProduct.Name} e estoque: {i.InputCreateProduct.Stock}, não pode ser cadastrado, pois o estoque não pode ser negativo.")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputCreateProduct.Name.Length > 40 || string.IsNullOrEmpty(i.InputCreateProduct.Name) || string.IsNullOrWhiteSpace(i.InputCreateProduct.Name)
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage(i.InputCreateProduct.Name.Length > 40 ? $"O Produto com Nome: {i.InputCreateProduct.Name}, não pode ser cadastrado, pois ultrapassa o limite de 40 caracteres."
             : "Não é possivel cadastrar produto com nome vazio")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputCreateProduct.Description.Length > 100 || string.IsNullOrEmpty(i.InputCreateProduct.Description) || string.IsNullOrWhiteSpace(i.InputCreateProduct.Description)
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage(i.InputCreateProduct.Description.Length > 40 ? $"O Produto com Nome: {i.InputCreateProduct.Name}, e com a descrição: {i.InputCreateProduct.Description} não pode ser cadastrado, pois ultrapassa o limite de 100 caracteres."
             : $"O Produto com Nome: {i.InputCreateProduct.Name}, não pode ser cadastrado, pois sua descrição está vazia")
             select i).ToList();

        _ = (from i in listProductValidate
             where string.IsNullOrEmpty(i.InputCreateProduct.ImageURL) || string.IsNullOrWhiteSpace(i.InputCreateProduct.ImageURL)
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputCreateProduct.Name} não pode ser cadastrado, pois contém a imagemURL vazia.")
             select i).ToList();

        var create = (from i in listProductValidate
                      where !i.Invalid
                      select i).ToList();

        if (!create.Any())
        {
            response.Success = false;
            return response;
        }

        response.Content = create;
        return response;
    }
    public BaseResponse<List<ProductValidate>> Update(List<ProductValidate> listProductValidate)
    {
        var response = new BaseResponse<List<ProductValidate>>();

        _ = (from i in listProductValidate
             where i.RepeteIdentify != 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Id: {i.dateProduct.Id} não pode ser atualizado, por ser repetido")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.ProductDTO == null
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Id: {i..Id} não pode ser atualizado, por não existir")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.CategoryId == 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputIdentifyUpdateProduct.InputUpdateProduct.Name} e o Id de Categoria: {i.InputIdentifyUpdateProduct.InputUpdateProduct.CategoryId}, não pode ser atualizado pois não existe nenhuma categoria com esse id, verifique os dados.")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputCreateProduct.Price < 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputIdentifyUpdateProduct.InputUpdateProduct.Name} e preço: {i.InputIdentifyUpdateProduct.InputUpdateProduct.Price}, não pode ser atualizado, pois o preço não pode ser negativo.")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputCreateProduct.Stock < 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputIdentifyUpdateProduct.InputUpdateProduct.Name} e estoque: {i.InputIdentifyUpdateProduct.InputUpdateProduct.Stock}, não pode ser atualizado, pois o estoque não pode ser negativo.")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputIdentifyUpdateProduct.InputUpdateProduct.Name.Length > 40 || string.IsNullOrEmpty(i.InputIdentifyUpdateProduct.InputUpdateProduct.Name) || string.IsNullOrWhiteSpace(i.InputIdentifyUpdateProduct.InputUpdateProduct.Name)
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage(i.InputIdentifyUpdateProduct.InputUpdateProduct.Name.Length > 40 ? $"O Produto com Nome: {i.InputIdentifyUpdateProduct.InputUpdateProduct.Name}, não pode ser atualizado, pois ultrapassa o limite de 40 caracteres."
             : "Não é possivel atualizar produto com nome vazio")
             select i).ToList();

        _ = (from i in listProductValidate
             where i.InputIdentifyUpdateProduct.InputUpdateProduct.Description.Length > 100 || string.IsNullOrEmpty(i.InputIdentifyUpdateProduct.InputUpdateProduct.Description) || string.IsNullOrWhiteSpace(i.InputIdentifyUpdateProduct.InputUpdateProduct.Description)
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage(i.InputUpdateProduct.Description.Length > 40 ? $"O Produto com Nome: {i.InputUpdateProduct.Name}, e com a descrição: {i.InputUpdateProduct.Description} não pode ser atualizado, pois ultrapassa o limite de 100 caracteres."
             : $"O Produto com Nome: {i.InputUpdateProduct.Name}, não pode ser atualizado, pois sua descrição está vazia")
             select i).ToList();

        _ = (from i in listProductValidate
             where string.IsNullOrEmpty(i.InputIdentifyUpdateProduct.InputUpdateProduct.ImageURL) || string.IsNullOrWhiteSpace(i.InputIdentifyUpdateProduct.InputUpdateProduct.ImageURL)
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Produto com Nome: {i.InputUpdateProduct.Name} não pode ser atualizado, pois contém a imagemURL vazia.")
             select i).ToList();

        var update = (from i in listProductValidate
                      where !i.Invalid
                      select i).ToList();

        if (!update.Any())
        {
            response.Success = false;
            return response;
        }

        response.Content = update;
        return response;
    }

    public BaseResponse<List<ProductValidate>> Delete(List<ProductValidate> listProductValidate)
    {
        throw new NotImplementedException();
    }

}
