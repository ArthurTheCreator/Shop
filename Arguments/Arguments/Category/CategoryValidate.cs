using Arguments.Arguments.Base;

namespace Arguments.Arguments.Category;

public class CategoryValidate : BaseValidate
{
    public InputCreateCategory InputCreateCategory { get; private set; }
    public InputIdentityUpdateCategory InputIdentityUpdateCategory { get; private set; }
    public long RepetedIdentify { get; private set; }
    public InputIdentityDeleteCategory InputIdentityDeleteCategory { get; private set; }
    public CategoryDTO CategoryDTO { get; private set; }
    public long HasProductId { get; private set; }

    public CategoryValidate Create(InputCreateCategory inputCreateCategory)
    {
        InputCreateCategory = inputCreateCategory;
        return this;
    }

    public CategoryValidate Update(InputIdentityUpdateCategory inputIdentifyUpdateCategory, CategoryDTO categoryDTO, long repetedIdentify)
    {
        InputIdentityUpdateCategory = inputIdentifyUpdateCategory;
        CategoryDTO = categoryDTO;
        RepetedIdentify = repetedIdentify;
        return this;
    }

    public CategoryValidate Delete(InputIdentityDeleteCategory inputIdentifyDeleteCategory, CategoryDTO CategoryExists, long repetedIdentify, long hasProductId)
    {
        InputIdentityDeleteCategory = inputIdentifyDeleteCategory;
        CategoryDTO = CategoryExists;
        RepetedIdentify = repetedIdentify;
        HasProductId = hasProductId;
        return this;
    }

}