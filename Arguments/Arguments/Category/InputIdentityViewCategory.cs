using Arguments.Arguments.Base;
using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentityViewCategory(long id) : BaseInputIdentityView<InputIdentityViewCategory>, IHashId
{
    public long Id { get; private set; } = id;
}