using AutoMapper;
using Entities;
using Handlers.Products.Commands.UpdateProduct;

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
