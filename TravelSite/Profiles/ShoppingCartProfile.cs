using AutoMapper;
using TravelSite.Dtos;
using TravelSite.Models;

namespace TravelSite.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile() 
        { 
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<LineItem, LineItemDto>();
        }

    }
}
