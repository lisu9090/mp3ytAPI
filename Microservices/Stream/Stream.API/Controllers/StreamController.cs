using APIComponents.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Stream.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamController : BaseController
    {
        public StreamController(ILogger logger) : base(logger) 
        {

        }

        [HttpGet("desc/{vid}")]
        public /*async*/ IActionResult GetAudioDescription(string vid)
        {
            return Ok();
        }

        [HttpGet("audio/{vid}")]
        public /*async*/ IActionResult GetAudioStream(string vid)
        {
            return Ok();
        }
    }
}