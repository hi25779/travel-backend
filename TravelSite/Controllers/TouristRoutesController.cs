using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TravelSite.Models;
using TravelSite.Services;
using AutoMapper;
using System.Collections.Generic;
using TravelSite.Dtos;

namespace TravelSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : Controller
    {
        private ITouristRouteRepository _touristRouteRepository;

        private readonly IMapper _mapper;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }

        // /api/touristroutes?keyword=xxx
        [HttpGet]
        public IActionResult GetTouristRoutes([FromQuery] string keyword)
        {
            var routesFromRepo = _touristRouteRepository.GetTouristRoutes(keyword);
            if (routesFromRepo == null || routesFromRepo.Count() == 0)
            {
                return NotFound("There is no routes");
            }
            var routesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(routesFromRepo);
            return Ok(routesDto);
        }

        // api/touristroutes/{touristRouteId}
        [HttpGet("{touristRouteId:Guid}")]
        public IActionResult GetTouristRoutesById(Guid touristRouteId)
        {
            var routesFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (routesFromRepo == null)
            {
                return NotFound($"There is no {touristRouteId} route.");
            }
            var routeDto = _mapper.Map<TouristRouteDto>(routesFromRepo);
            return Ok(routeDto);
        }
    }
}
