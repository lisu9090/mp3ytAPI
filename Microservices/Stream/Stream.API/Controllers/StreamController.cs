using APIComponents.Controllers;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [Route("desc")]
        public /*async*/ IActionResult GetAudioDescription(string vid)
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(System.IO.Stream))]
        [Route("audio")]
        public async Task<IActionResult> GetAudioStream(string vid)
        {
            var outputStream = await _audioStreamService.GetAudioStreamAsync(vid);

            return Ok(outputStream);
        }
    }
}