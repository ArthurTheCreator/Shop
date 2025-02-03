using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentityUpdateCategory(long id, InputUpdateCategory inputUpdateCategory) : BaseInputIdentityUpdate<InputIdentityUpdateCategory>
{
    public long Id { get; private set; } = id;
    public InputUpdateCategory InputUpdateCategory { get; private set; } = inputUpdateCategory;
}