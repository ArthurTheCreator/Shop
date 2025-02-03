using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentityDeleteCategory(long id) : BaseInputIdentityDelete<InputIdentityDeleteCategory>
{
    public long Id { get; private set; } = id;
}