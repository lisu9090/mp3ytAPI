using APIComponents.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stream.Domain.Abstract.Services;
using System.Threading.Tasks;

namespace Stream.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamController : BaseController
    {
        private IAudioStreamService _audioStreamService;

        public StreamController(IAudioStreamService audioStreamService, ILogger logger) : base(logger) 
        {
            _audioStreamService = audioStreamService;
        }

        [HttpGet("desc/{vid}")]
        public /*async*/ IActionResult GetAudioDescription(string vid)
        {
            return Ok();
        }

        [HttpGet("audio/{vid}")]
        public async Task<IActionResult> GetAudioStream(string vid)
        {
            var outputStream = await _audioStreamService.GetAudioStreamAsync(vid);

            return Ok(outputStream);
        }
    }
}