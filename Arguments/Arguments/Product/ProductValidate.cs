using Arguments.Arguments.Base;

namespace Arguments.Arguments.Product;

public class ProductValidate : BaseValidate
{
    public InputCreateProduct InputCreateProduct { get; private set; }
    public InputIdentifyUpdateProduct InputIdentifyUpdateProduct { get; private set; }
    public long CategoryId { get; private set; }
    public ProductDTO ProductDTO { get; private set; }
    public long RepeteIdentify { get; private set; }

    public ProductValidate Create (InputCreateProduct inputCreateProduct, long brandId)
    {
        InputCreateProduct = inputCreateProduct;
        CategoryId = brandId;
        return this;
    }
    public ProductValidate Update(InputIdentifyUpdateProduct inputIdentifyUpdateProduct, ProductDTO productDTO, long categoryId,  long repeteIdentify)
    {
        InputIdentifyUpdateProduct = inputIdentifyUpdateProduct;
        CategoryId = categoryId;
        ProductDTO = productDTO;
        RepeteIdentify = repeteIdentify;
        return this;
    }
}