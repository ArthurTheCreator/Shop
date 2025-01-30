using Arguments.Arguments.Category;

namespace Arguments.Arguments;

public class ProductDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public long CategoryId { get; set; }
    public string? ImageURL { get; set; }

    public CategoryDTO Category { get; set; }

    public ProductDTO() { }

    public ProductDTO(long id, string? name, string? description, decimal price, long stock, long categoryId, string? imageURL)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
        ImageURL = imageURL;
    }
}
