using Microsoft.AspNetCore.Mvc;

namespace LoadTesting.Api.Controllers
{
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        [HttpGet("youtube")]
        public IActionResult GetYoutubeChannelDetails()
        {
            return Ok(new
            {
                Subscribers = 14510
            });
        }

        [HttpGet("github")]
        public IActionResult GetGithubDetails()
        {
            return Ok(new
            {
                Followers = 1956
            });
        }

        [HttpGet("twitter")]
        public IActionResult GetTwitterDetails()
        {
            return Ok(new
            {
                Followers = 1600
            });
        }
    }
}
