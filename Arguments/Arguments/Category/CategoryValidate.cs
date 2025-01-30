using Arguments.Arguments.Base;

namespace Arguments.Arguments.Category;

public class CategoryValidate : BaseValidate
{
    public InputCreateCategory InputCreateCategory { get; private set; }
    public InputIdentifyUpdateCategory InputIdentifyUpdateCategory { get; private set; }
    public long RepetedIdentify { get; private set; }
    public InputIdentifyDeleteCategory InputIdentifyDeleteCategory { get; private set; }
    public CategoryDTO CategoryDTO { get; private set; }

    public CategoryValidate Create(InputCreateCategory inputCreateCategory)
    {
        InputCreateCategory = inputCreateCategory;
        return this;
    }

    public CategoryValidate Update(InputIdentifyUpdateCategory inputIdentifyUpdateCategory, CategoryDTO categoryDTO, long repetedIdentify)
    {
        InputIdentifyUpdateCategory = inputIdentifyUpdateCategory;
        CategoryDTO = categoryDTO;
        RepetedIdentify = repetedIdentify;
        return this;
    }

    public CategoryValidate Delete(InputIdentifyDeleteCategory inputIdentifyDeleteCategory, CategoryDTO CategoryExists,long repetedIdentify)
    {
        InputIdentifyDeleteCategory = inputIdentifyDeleteCategory;
        CategoryDTO = CategoryExists;
        RepetedIdentify = repetedIdentify;
        return this;
    }

}