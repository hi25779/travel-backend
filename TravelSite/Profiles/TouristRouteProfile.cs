using AutoMapper;
using System;
using TravelSite.Dtos;
using TravelSite.Models;
using TravelSite.Models.Params;
using TravelSite.Params;

namespace TravelSite.Profiles
{
    public class TouristRouteProfile: Profile
    {
        public TouristRouteProfile() {
            CreateMap<TouristRoute, TouristRouteDto>()
                .ForMember(
                    dest => dest.price,
                    opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPresent ?? 1))
                )
                .ForMember(
                    dest => dest.TravelDays,
                    opt => opt.MapFrom(src => src.TravelDays.ToString())

                )
                .ForMember(
                    dest => dest.TripType,
                    opt => opt.MapFrom(src => src.TripType.ToString())

                )
                .ForMember(
                    dest => dest.DepartureCity,
                    opt => opt.MapFrom(src => src.DepartureCity.ToString())

                );

            CreateMap<TouristRouteFromCreationParam, TouristRoute>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                );


        }
    }
}
