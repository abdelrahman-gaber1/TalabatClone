using AutoMapper;
using Talabat.APIS.DTOs;
using Talabat.Core.Models;

namespace Talabat.APIS.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(S => S.Brand.Name))
                .ForMember(d => d.Category, o => o.MapFrom(S => S.Category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
