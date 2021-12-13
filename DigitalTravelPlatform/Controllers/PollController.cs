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
    public class PollController
    {
        private readonly ILogger<PollController> _logger;
        private readonly DTPProcessor _processor;

        public PollController(ILogger<PollController> logger, DTPProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [Authorize]
        [HttpPost(Name = nameof(GetQuestion))]
        public async Task<Question> GetQuestion([FromBody] short pollId)
        {
            try
            {
                var result = await _processor.GetQuestion(pollId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return default;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(GetAnswer))]
        public async Task<List<Answer>> GetAnswer([FromBody] short pollId)
        {
            try
            {
                var result = await _processor.GetAnswer(pollId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return default;
            }
        }

        [Authorize]
        [HttpPost(Name = nameof(PullAnswer))]
        public async Task<bool> PullAnswer([FromBody] short answerId)
        {
            try
            {
                var result = await _processor.PullAnswer(answerId);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occurred: {ex.Message}");
                return false;
            }
        }
    }
}
