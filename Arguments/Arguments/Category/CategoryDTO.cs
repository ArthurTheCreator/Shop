namespace Arguments.Arguments.Category;

public class CategoryDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<ProductDTO> listProduct { get; set; }

    public CategoryDTO() { }

    public CategoryDTO(long id, string? name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
