using AutoMapper;
using ProductManage.Models;
using ProductManage.ProductOperations.CreateProduct;
using ProductManage.ProductOperations.GetProductDetail;
using ProductManage.ProductOperations.GetProducts;

namespace ProductManage.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductModel, Product>().ReverseMap();
        CreateMap<ProductDetailViewModel, Product>().ReverseMap().ForMember(dest => dest.Genre,
            opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        CreateMap<ProductViewModel, Product>().ReverseMap().ForMember(dest => dest.Genre,
            opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));;
    }
}