using Microsoft.EntityFrameworkCore;
using System;
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
            return _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword)
        {
            IQueryable<TouristRoute> result = _context.TouristRoutes.Include(t => t.TouristRoutePictures);
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(t => t.Title.Contains(keyword));
            }
            return result.ToList();
        }

        public bool HasTouristRoute(Guid id)
        {
             return _context.TouristRoutes.Any(t => t.Id == id);
        }
        public IEnumerable<TouristRoutePicture> GetTouristRoutePicturesById(Guid id)
        {
            return _context.TouristRoutesPictures.Where(p => p.TouristRouteId == id).ToList();
        }

        public TouristRoutePicture GetPictureById(int pictureId)
        {
            return _context.TouristRoutesPictures.Where(p => p.Id == pictureId).FirstOrDefault();
        }

    }
}
