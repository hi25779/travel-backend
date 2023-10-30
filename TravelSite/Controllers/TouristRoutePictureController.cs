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
        public IActionResult GetPictureListForTouristRoute(Guid routeId)
        {
            if (!_repository.HasTouristRoute(routeId))
            {
                return NotFound($"Don't have this tourist route: {routeId}");
            }
            var pictureFromRepo = _repository.GetTouristRoutePicturesById(routeId);
            if (pictureFromRepo == null || pictureFromRepo.Count() <= 0)
            {
                return NotFound("This route don't has picture");
            }
            return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(pictureFromRepo));

        }

        [Route("{pictureId}", Name = "GetPicture")]
        [HttpGet]
        public IActionResult GetPicture(Guid routeId, int pictureId)
        {
            if (!_repository.HasTouristRoute(routeId))
            {
                return NotFound($"Don't have this tourist route: {routeId}");
            }
            var pictureFromRepo = _repository.GetPictureById(pictureId);
            if (pictureFromRepo == null) 
            {
                return NotFound("Can't find this picture");
            }
            return Ok(_mapper.Map<TouristRoutePictureDto>(pictureFromRepo));
        }

        public IActionResult CreateTouristPicture(
            [FromRoute] Guid routeId,
            [FromBody] TouristRoutePictureForCreate touristRoutePictureParam
            )
        {
            if (!_repository.HasTouristRoute(routeId))
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

    }
}
