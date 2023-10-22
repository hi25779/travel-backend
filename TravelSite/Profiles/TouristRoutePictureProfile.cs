using AutoMapper;
using TravelSite.Dtos;
using TravelSite.Models;
using TravelSite.Models.Params;

namespace TravelSite.Profiles
{
    public class TouristRoutePictureProfile: Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
            CreateMap<TouristRoutePictureParam, TouristRoutePicture > ();
        }
    }
}
