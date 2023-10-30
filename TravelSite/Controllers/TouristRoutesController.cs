using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TravelSite.Models;
using TravelSite.Services;
using AutoMapper;
using System.Collections.Generic;
using TravelSite.Dtos;
using TravelSite.Dtos.Create;
using TravelSite.Dtos.Update;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{touristRouteId:Guid}", Name = "GetTouristRoutesById")]
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

        [HttpPost]
        public IActionResult CreateTouristRoute([FromBody] TouristRouteForCreate touristRouteFromCreationParam)
        {
            var touristRouteModel = _mapper.Map<TouristRoute>(touristRouteFromCreationParam);
            _touristRouteRepository.AddTouristRoute(touristRouteModel);
            var touristRouteDto = _mapper.Map<TouristRouteDto>(touristRouteModel);
            return CreatedAtRoute(
                "GetTouristRoutesById", 
                new { touristRouteId = touristRouteDto.Id }, 
                touristRouteDto
                );
        }

        [HttpPut("{touristRouteId}")]
        public IActionResult UpdateTouristRoute(
            [FromRoute]Guid touristRouteId,
            [FromBody]TouristRouteForUpdate touristRouteParam
            )
        {
            if (!_touristRouteRepository.HasTouristRoute(touristRouteId))
            {
                return NotFound($"There is no {touristRouteId} route.");
            }
            var model = _touristRouteRepository.GetTouristRoute(touristRouteId);
            _mapper.Map(touristRouteParam, model);
            _touristRouteRepository.Save();
            return NoContent();
        }

        [HttpPatch("{touristRouteId}")]
        public IActionResult PartiallyUpdateTouristRoute(
                [FromRoute] Guid touristRouteId,
                [FromBody] JsonPatchDocument<TouristRouteForUpdate> patchDocument
            )
        {
            if (!_touristRouteRepository.HasTouristRoute(touristRouteId))
            {
                return NotFound($"There is no {touristRouteId} route.");
            }
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            var touristRouteToPatch = _mapper.Map<TouristRouteForUpdate>(touristRouteFromRepo);
            patchDocument.ApplyTo(touristRouteToPatch);

            _mapper.Map(touristRouteToPatch, touristRouteFromRepo);
            _touristRouteRepository.Save();
            return NoContent();

        }
    }
}
