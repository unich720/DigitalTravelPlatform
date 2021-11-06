using DTP.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalTravelPlatform.Controllers
{

    [ApiController]
    [Route("api/[action]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly DTPDBContext _contextDTP;


        public ClientController(ILogger<ClientController> logger, DTPDBContext contextDTP)
        {
            _logger = logger;
            _contextDTP = contextDTP;
        }


        [HttpPost(Name = nameof(GetRofl))]
        public async Task<JsonResult> GetRofl([FromBody] string param)
        {
            try
            {
                return default;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
            }
        }







    }



}
