using AutoMapper;
using Entities;
using Handlers.Products.Commands.Dto;

namespace WebHost
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Product>();                
        }
    }
}
