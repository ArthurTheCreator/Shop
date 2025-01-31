using Arguments.Arguments.Base;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentityViewCategory(long id) : IHashId
{
    public long Id { get; private set; } = id;
}