using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TravelSite.controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/shoudongapi")]
    public class MaunalAPIController
    {
        [HttpGet]
        public IEnumerable<string> get()
        {
            return new[] { "v1", "v2" };
        }

    }
}
