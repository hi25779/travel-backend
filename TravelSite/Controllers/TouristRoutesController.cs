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
using FakeXiecheng.API.Helper;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetTouristRoutesAsync([FromQuery] string keyword)
        {
            var routesFromRepo = await _touristRouteRepository.GetTouristRoutesAsync(keyword);
            if (routesFromRepo == null || routesFromRepo.Count() == 0)
            {
                return NotFound("There is no routes");
            }
            var routesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(routesFromRepo);
            return Ok(routesDto);
        }

        // api/touristroutes/{touristRouteId}
        [HttpGet("{touristRouteId:Guid}", Name = "GetTouristRoutesById")]
        public async Task<IActionResult> GetTouristRoutesById(Guid touristRouteId)
        {
            var routesFromRepo = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);
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
        public async Task<IActionResult> UpdateTouristRoute(
            [FromRoute]Guid touristRouteId,
            [FromBody]TouristRouteForUpdate touristRouteParam
            )
        {
            if (!(await _touristRouteRepository.HasTouristRouteAsync(touristRouteId)))
            {
                return NotFound($"There is no {touristRouteId} route.");
            }
            var model = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            _mapper.Map(touristRouteParam, model);
            await _touristRouteRepository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{touristRouteId}")]
        public async Task<IActionResult> PartiallyUpdateTouristRoute(
                [FromRoute] Guid touristRouteId,
                [FromBody] JsonPatchDocument<TouristRouteForUpdate> patchDocument
            )
        {
            if (!(await _touristRouteRepository.HasTouristRouteAsync(touristRouteId)))
            {
                return NotFound($"There is no {touristRouteId} route.");
            }
            var touristRouteFromRepo = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            var touristRouteToPatch = _mapper.Map<TouristRouteForUpdate>(touristRouteFromRepo);
            patchDocument.ApplyTo(touristRouteToPatch);

            _mapper.Map(touristRouteToPatch, touristRouteFromRepo);
            await _touristRouteRepository.SaveAsync();
            return NoContent();

        }

        [HttpDelete("{touristRouteId}")]
        public async Task<IActionResult> DeleteTouristRoute([FromRoute]Guid touristRouteId)
        {
            if (!(await _touristRouteRepository.HasTouristRouteAsync(touristRouteId)))
            {
                return NotFound($"There is no {touristRouteId} route.");
            }
            var touristRoute = await _touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            _touristRouteRepository.DeleteTouristRoute(touristRoute);
            await _touristRouteRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("({touristIDs})")]
        public IActionResult DeleteTouristRouteByIDs(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))][FromRoute]IEnumerable<Guid> touristIDs)
        {
            foreach( var id in touristIDs)
            {
                Console.WriteLine(id);
            }
            
            return NoContent();
        }
    }
}
