using System;
using System.Collections;
using System.Collections.Generic;
using TravelSite.Models;

namespace TravelSite.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword);
        TouristRoute GetTouristRoute(Guid id);
        bool HasTouristRoute(Guid id);
        IEnumerable<TouristRoutePicture> GetTouristRoutePicturesById(Guid id);
        TouristRoutePicture GetPictureById(int pictureId);
        void AddTouristRoute(TouristRoute touristRoute);
        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        bool Save();
    }
}
