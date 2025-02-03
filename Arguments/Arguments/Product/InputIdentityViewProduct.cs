using Arguments.Arguments.Base;
using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Product;

[method: JsonConstructor]
public class InputIdentityViewProduct(long id) : BaseInputIdentityView<InputIdentityViewProduct>, IHashId
{
    public long Id { get; private set; } = id;
}