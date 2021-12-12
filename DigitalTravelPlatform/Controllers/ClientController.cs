using DigitalTravelPlatform.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DigitalTravelPlatform.Controllers
{

    [ApiController]
    [Route("api/[action]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly DTPProcessor _processor;

        public ClientController(ILogger<ClientController> logger, DTPProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [Authorize]
        [HttpPost(Name = nameof(Login))]
        public async Task<bool> Login([FromBody] ClientLogin clientLogin)
        {
            try
            {
                var result = await _processor.Login(clientLogin.Login, clientLogin.Password);

                _logger.LogInformation($"{clientLogin.Login} is login {result}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return false;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(GetProfile))]
        public async Task<Profile> GetProfile([FromBody] string login)
        {
            try
            {
                var result = await _processor.GetProfile(login);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return default;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(ChangePassword))]
        public async Task<bool> ChangePassword([FromBody] CPassword cPassword)
        {
            try
            {
                var result = await _processor.ChangePassword(cPassword.Login, cPassword.Password);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return false;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(ChangeProfile))]
        public async Task<bool> ChangeProfile([FromBody] Profile cProfile)
        {
            try
            {
                var result = await _processor.ChangeProfile(cProfile);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return false;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(GivePointsUser))]
        public async Task<bool> GivePointsUser([FromBody] UserPoints userPoints)
        {
            try
            {
                var result = await _processor.GivePointsUser(userPoints);

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
