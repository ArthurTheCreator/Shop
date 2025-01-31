using Arguments.Arguments;
using Arguments.Arguments.Category;
using Arguments.Arguments.Product;
using AutoMapper;
using Infrastructure.Persistence.Entity;

namespace Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, OutputProduct>()
            .ForMember(i => i.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Category, OutputCategory>();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
