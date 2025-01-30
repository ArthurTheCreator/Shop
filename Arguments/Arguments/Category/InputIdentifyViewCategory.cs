using Arguments.Arguments.Base;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentifyViewCategory(long id) : IHashId
{
    public long Id { get; private set; } = id;
}