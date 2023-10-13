using System;
using System.Collections;
using System.Collections.Generic;
using TravelSite.Models;

namespace TravelSite.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid id);

    }
}
