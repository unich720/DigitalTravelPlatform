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
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DTPDBContext _contextDTP;


        public ClientController(ILogger<WeatherForecastController> logger, DTPDBContext contextDTP)
        {
            _logger = logger;
            _contextDTP = contextDTP;
        }


        [HttpPost]
        public JsonResult Get()
        {
           
        }







    }



}
