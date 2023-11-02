using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelSite.Dtos;
using TravelSite.Dtos.Create;
using TravelSite.Models;
using TravelSite.Services;
using System.Threading.Tasks;

namespace TravelSite.Controllers
{
    [Route("api/touristRoutes/{routeId}/pictures")]
    [ApiController]
    public class TouristRoutePictureController : ControllerBase
    {
        private ITouristRouteRepository _repository;

        private IMapper _mapper;

        public TouristRoutePictureController(ITouristRouteRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetPictureListForTouristRoute(Guid routeId)
        {
            if (!(await _repository.HasTouristRouteAsync(routeId)))
            {
                return NotFound($"Don't have this tourist route: {routeId}");
            }
            var pictureFromRepo = await _repository.GetTouristRoutePicturesByIdAsync(routeId);
            if (pictureFromRepo == null || pictureFromRepo.Count() <= 0)
            {
                return NotFound("This route don't has picture");
            }
            return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(pictureFromRepo));

        }

        [Route("{pictureId}", Name = "GetPicture")]
        [HttpGet]
        public async Task<IActionResult> GetPicture(Guid routeId, int pictureId)
        {
            if (!(await _repository.HasTouristRouteAsync(routeId)))
            {
                return NotFound($"Don't have this tourist route: {routeId}");
            }
            var pictureFromRepo = await _repository.GetPictureByIdAsync(pictureId);
            if (pictureFromRepo == null) 
            {
                return NotFound("Can't find this picture");
            }
            return Ok(_mapper.Map<TouristRoutePictureDto>(pictureFromRepo));
        }

        public async Task<IActionResult> CreateTouristPicture(
            [FromRoute] Guid routeId,
            [FromBody] TouristRoutePictureForCreate touristRoutePictureParam
            )
        {
            if (!(await _repository.HasTouristRouteAsync(routeId)))
            {
                return NotFound($"Don't have this tourist route: {routeId}");
            }
            var pictureModel = _mapper.Map<TouristRoutePicture>(touristRoutePictureParam);
            _repository.AddTouristRoutePicture(routeId, pictureModel);
            var pictureDto = _mapper.Map<TouristRoutePictureDto>(pictureModel);
            return CreatedAtRoute(
                "GetPicture",
                new
                {
                    routeId = pictureModel.TouristRouteId,
                    pictureId = pictureModel.Id
                },
                pictureDto
                );
        }

        [HttpDelete("{pictureId}")]
        public async Task<IActionResult> DeleteTouristRoutePicture(
            [FromRoute]Guid routeId,
            [FromRoute]int pictureId)
        {
            if (!(await _repository.HasTouristRouteAsync(routeId)))
            {
                return NotFound($"Don't have this tourist route: {routeId}");
            }
            var pictureFromRepo = await _repository.GetPictureByIdAsync(pictureId);
            if (pictureFromRepo == null)
            {
                return NotFound("Can't find this picture");
            }
            _repository.DeleteTouristRoutePicture(pictureFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}
