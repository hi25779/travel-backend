using AutoMapper;
using TravelSite.Dtos;
using TravelSite.Models;

namespace TravelSite.Profiles
{
    public class TouristRoutePictureProfile: Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
        }
    }
}
