using Arguments.Arguments.Base;
using Arguments.Arguments.Category;
using Infrastructure.Interface.ValidateService;

namespace Infrastructure.Application.Service.Category;

public class CategoryValidateService : ICategoryValidateService
{
    #region Create
    public BaseResponse<List<CategoryValidate>> Create(List<CategoryValidate> listCategoryValidate)
    {
        var response = new BaseResponse<List<CategoryValidate>>();

        if (listCategoryValidate == null)
        {
            response.AddErrorMessage("Não é possivél cadastrar uma categoria vazia.");
            response.Success = false;
            return response;
        }

        _ = (from i in listCategoryValidate
             where i == null
             let setInvalid = i.SetInvalid()
             select i).ToList();

        _ = (from i in listCategoryValidate
             where i.InputCreateCategory.Name.Length > 40 || string.IsNullOrEmpty(i.InputCreateCategory.Name) || string.IsNullOrWhiteSpace(i.InputCreateCategory.Name)
             let setInvalid = i.SetInvalid()
             let message = response.AddSuccessMessage(i.InputCreateCategory.Name.Length > 40 ? $"A categoria com o nome {i.InputCreateCategory.Name} não pode ser cadastrada, pois ultrapassa o limite de 40 caracteres."
             : "Não é possível criar uma categoria com nome vazio.")
             select i).ToList();

        _ = (from i in listCategoryValidate
             where i.InputCreateCategory.Description.Length > 100 || string.IsNullOrEmpty(i.InputCreateCategory.Description) || string.IsNullOrWhiteSpace(i.InputCreateCategory.Description)
             let setInvalid = i.SetInvalid()
             let message = response.AddSuccessMessage(i.InputCreateCategory.Description.Length > 100 ? $"A categoria com o nome {i.InputCreateCategory.Name} não pode ser cadastrada, pois a descrição {i.InputCreateCategory.Description} ultrapassa o limite máximo de 100 caracteres."
             : $"A categoria com o nome {i.InputCreateCategory.Name} não pode ser cadastrada, pois a descrição está vazia.")
             select i).ToList();

        var create = (from i in listCategoryValidate
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
    #endregion

    #region Update
    public BaseResponse<List<CategoryValidate>> Update(List<CategoryValidate> listCategoryValidate)
    {
        var response = new BaseResponse<List<CategoryValidate>>();

        _ = (from i in listCategoryValidate
             where i.RepetedIdentify != 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"A Categoria com Id: {i.InputIdentityUpdateCategory.Id} não pode ser atualizado, por ser repetido")
             select i).ToList();

        _ = (from i in listCategoryValidate
             where i.CategoryDTO == null
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"A Categoria com Id: {i.InputIdentityUpdateCategory.Id} não pode ser atualizado, por não existir")
             select i).ToList();

        _ = (from i in listCategoryValidate
             where i.InputIdentityUpdateCategory.InputUpdateCategory.Name.Length > 40 || string.IsNullOrEmpty(i.InputIdentityUpdateCategory.InputUpdateCategory.Name) || string.IsNullOrWhiteSpace(i.InputIdentityUpdateCategory.InputUpdateCategory.Name)
             let setInvalid = i.SetInvalid()
             let message = response.AddSuccessMessage(i.InputIdentityUpdateCategory.InputUpdateCategory.Name.Length > 40 ? $"A categoria com o nome {i.InputIdentityUpdateCategory.InputUpdateCategory.Name} não pode ser autalizada, pois ultrapassa o limite de 40 caracteres."
             : "Não é possível atualizar uma categoria com nome vazio.")
             select i).ToList();

        _ = (from i in listCategoryValidate
             where i.InputIdentityUpdateCategory.InputUpdateCategory.Description.Length > 100 || string.IsNullOrEmpty(i.InputIdentityUpdateCategory.InputUpdateCategory.Description) || string.IsNullOrWhiteSpace(i.InputIdentityUpdateCategory.InputUpdateCategory.Description)
             let setInvalid = i.SetInvalid()
             let message = response.AddSuccessMessage(i.InputIdentityUpdateCategory.InputUpdateCategory.Description.Length > 100 ? $"A categoria com o nome {i.InputIdentityUpdateCategory.InputUpdateCategory.Name} não pode ser atualizar, pois a descrição {i.InputIdentityUpdateCategory.InputUpdateCategory.Description} ultrapassa o limite máximo de 100 caracteres."
             : $"A categoria com o nome {i.InputIdentityUpdateCategory.InputUpdateCategory.Name} não pode ser atualizar, pois a descrição está vazia.")
             select i).ToList();

        var update = (from i in listCategoryValidate
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
    #endregion

    #region Delete
    public BaseResponse<List<CategoryValidate>> Delete(List<CategoryValidate> listCategoryValidate)
    {
        var response = new BaseResponse<List<CategoryValidate>>();

        _ = (from i in listCategoryValidate
             where i.RepetedIdentify != 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"O Id: {i.InputIdentityDeleteCategory.Id} foi digitado repetidas vezes, não é possível deletar a categoria com esse Id")
             select i).ToList();

        _ = (from i in listCategoryValidate
             where i.CategoryDTO == null
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"Categoria com ID: {i.InputIdentityDeleteCategory.Id} é inválida. Verifique os dados.")
             select i).ToList();

        _ = (from i in listCategoryValidate
             where i.HasProductId != 0
             let setInvalid = i.SetInvalid()
             let message = response.AddErrorMessage($"Categoria com ID: {i.InputIdentityDeleteCategory.Id} não pode ser deletada, pois contém produtos relacionados.")
             select i).ToList();

        var delete = (from i in listCategoryValidate
                      where !i.Invalid
                      select i).ToList();

        if (!delete.Any())
        {
            response.Success = false;
            return response;
        }

        response.Content = delete;
        return response;
    }
    #endregion
}