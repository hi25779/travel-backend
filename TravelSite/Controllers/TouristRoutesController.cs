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

        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
            var routesFromRepo = _touristRouteRepository.GetTouristRoutes();
            if (routesFromRepo == null || routesFromRepo.Count() == 0)
            {
                return NotFound("There is no routes");
            }
            var routesDto = _mapper.Map<List<TouristRouteDto>>(routesFromRepo);
            return Ok(routesDto);
        }

        // api/touristroutes/{id}
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
