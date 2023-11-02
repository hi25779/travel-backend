using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TravelSite.Database;
using TravelSite.Models;
using System.Threading.Tasks;

namespace TravelSite.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;

        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<TouristRoute> GetTouristRouteAsync(Guid id)
        {
            return await _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TouristRoute>> GetTouristRoutesAsync(string keyword)
        {
            IQueryable<TouristRoute> result = _context.TouristRoutes.Include(t => t.TouristRoutePictures);
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(t => t.Title.Contains(keyword));
            }
            return await result.ToListAsync();
        }

        public async Task<bool> HasTouristRouteAsync(Guid id)
        {
             return await _context.TouristRoutes.AnyAsync(t => t.Id == id);
        }
        public async Task<IEnumerable<TouristRoutePicture>> GetTouristRoutePicturesByIdAsync(Guid id)
        {
            return await _context.TouristRoutesPictures.Where(p => p.TouristRouteId == id).ToListAsync();
        }

        public async Task<TouristRoutePicture> GetPictureByIdAsync(int pictureId)
        {
            return await _context.TouristRoutesPictures.Where(p => p.Id == pictureId).FirstOrDefaultAsync();
        }

        public void AddTouristRoute(TouristRoute touristRoute)
        {
            if (touristRoute == null)
            {
                throw new ArgumentNullException(nameof(touristRoute));
            }
            _context.TouristRoutes.Add(touristRoute);
            _context.SaveChanges();
        }

        public void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture)
        {
            if (touristRouteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(touristRouteId));
            }
            if (touristRoutePicture == null)
            {
                throw new ArgumentNullException(nameof(touristRoutePicture));

            }
            touristRoutePicture.TouristRouteId = touristRouteId;
            _context.Add(touristRoutePicture);
            _context.SaveChanges();
        }
        public void DeleteTouristRoute(TouristRoute touristRoute)
        {
            _context.TouristRoutes.Remove(touristRoute);
        }
        public void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture)
        {
            _context.TouristRoutesPictures.Remove(touristRoutePicture);
        }

        public async Task<bool> SaveAsync()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }

    }
}
