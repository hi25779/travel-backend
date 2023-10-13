﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TravelSite.Database;
using TravelSite.Models;

namespace TravelSite.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;

        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public TouristRoute GetTouristRoute(Guid id)
        {
            return _context.TouristRoutes.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.TouristRoutes;
        }
    }
}
