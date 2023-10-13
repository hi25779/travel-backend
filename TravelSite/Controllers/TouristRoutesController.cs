using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelSite.Services;

namespace TravelSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : Controller
    {
        private ITouristRouteRepository _touristRouteRepository;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }

        public IActionResult GetTouristRoutes()
        {
            return Ok(_touristRouteRepository.GetTouristRoutes());
        }
    }
}
