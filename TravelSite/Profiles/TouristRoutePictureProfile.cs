using AutoMapper;
using TravelSite.Dtos;
using TravelSite.Dtos.Create;
using TravelSite.Models;

namespace TravelSite.Profiles
{
    public class TouristRoutePictureProfile: Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
            CreateMap<TouristRoutePictureForCreate, TouristRoutePicture>();
            CreateMap<TouristRoutePicture, TouristRoutePictureForCreate>();
        }
    }
}
