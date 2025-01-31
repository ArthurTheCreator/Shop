using Arguments.Arguments.Base;

namespace Arguments.Arguments.Product;

public class ProductValidate : BaseValidate
{
    public InputCreateProduct InputCreateProduct { get; private set; }
    public InputIdentityUpdateProduct InputIdentityUpdateProduct { get; private set; }
    public InputIdentiityDeleteProduct InputIdentityDeleteProduct { get; private set; }
    public long CategoryId { get; private set; }
    public ProductDTO ProductDTO { get; private set; }
    public long RepeteIdentity { get; private set; }

    public ProductValidate Create(InputCreateProduct inputCreateProduct, long brandId)
    {
        InputCreateProduct = inputCreateProduct;
        CategoryId = brandId;
        return this;
    }
    public ProductValidate Update(InputIdentityUpdateProduct inputIdentifyUpdateProduct, ProductDTO productDTO, long categoryId, long repeteIdentify)
    {
        InputIdentityUpdateProduct = inputIdentifyUpdateProduct;
        CategoryId = categoryId;
        ProductDTO = productDTO;
        RepeteIdentity = repeteIdentify;
        return this;
    }

    public ProductValidate Delete(InputIdentiityDeleteProduct inputIdentifyDeleteProduct, ProductDTO productDTO, long repeteIdentify)
    {
        InputIdentityDeleteProduct = inputIdentifyDeleteProduct;
        ProductDTO = productDTO;
        RepeteIdentity = repeteIdentify;
        return this;
    }
}