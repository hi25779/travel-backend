using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSite.Controllers;
using TravelSite.Database;
using TravelSite.Services;

namespace TravelSite.Tests.ControllerTests
{
    public class TouristRouteControllerTest
    {
        private readonly Mock<TouristRoutesController> _controller;


        public TouristRouteControllerTest()
        {
            _controller = new Mock<TouristRoutesController>();
        }

        [Fact]
        public void Get_WhileCalled_ReturnOkResult()
        {
            //var okResult = await _controller.GetTouristRoutesAsync("");
            //Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
