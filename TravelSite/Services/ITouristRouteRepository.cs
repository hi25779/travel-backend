using System;
using System.Collections;
using System.Collections.Generic;
using TravelSite.Models;
using System.Threading.Tasks;

namespace TravelSite.Services
{
    public interface ITouristRouteRepository
    {
        Task<IEnumerable<TouristRoute>> GetTouristRoutesAsync(string keyword);
        Task<TouristRoute> GetTouristRouteAsync(Guid id);
        Task<bool> HasTouristRouteAsync(Guid id);
        Task<IEnumerable<TouristRoutePicture>> GetTouristRoutePicturesByIdAsync(Guid id);
        Task<TouristRoutePicture> GetPictureByIdAsync(int pictureId);
        void AddTouristRoute(TouristRoute touristRoute);
        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture);
        Task<bool> SaveAsync();
    }
}
