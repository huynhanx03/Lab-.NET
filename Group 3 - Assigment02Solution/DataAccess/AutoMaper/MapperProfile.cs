using AutoMapper;
using BusinessObject;

namespace DataAccess
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            #region Category
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId.ToString()));
            #endregion
            #region Product
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<ProductAddDto, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => Guid.Parse(src.CategoryId)));
            #endregion
            #region User
            #endregion
        }
    }
}
