using DTP.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalTravelPlatform.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class PlacesController : Controller
    {
        private readonly ILogger<PlacesController> _logger;
        private readonly DTPProcessor _processor;

        public PlacesController(ILogger<PlacesController> logger, DTPProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [Authorize]
        [HttpPost(Name = nameof(GetRoutes))]
        public async Task<List<Route>> GetRoutes()
        {
            try
            {
                var result = await _processor.GetRoutes();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return default;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(GetPlaces))]
        public async Task<List<Place>> GetPlaces([FromBody] short routeId)
        {
            try
            {
                var result = await _processor.GetPlaces(routeId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return default;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(GetPlacesForUser))]
        public async Task<List<string>> GetPlacesForUser([FromBody] short userId)
        {
            try
            {
                var result = await _processor.GetPlacesForUser(userId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return default;
            }
        }
    }
}
