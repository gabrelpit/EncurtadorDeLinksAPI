using LinkShortenerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortenerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly LinkShortenerService _linkShortenerService;

        public LinkController(LinkShortenerService linkShortenerService)
        {
            _linkShortenerService = linkShortenerService;
        }

        // POST: api/link/shorten
        [HttpPost("shorten")]
public IActionResult ShortenUrl([FromBody] LinkRequest linkRequest)
{
    if (string.IsNullOrEmpty(linkRequest?.LongUrl))
    {
        return BadRequest("A URL longa é obrigatória.");
    }

    var shortUrl = _linkShortenerService.ShortenUrl(linkRequest.LongUrl);
    return Ok(new { shortUrl = $"https://localhost:5001/api/link/{shortUrl}" });
}

public class LinkRequest
{
    public string LongUrl { get; set; }
}

        // GET: api/link/{shortUrl}
        [HttpGet("{shortUrl}")]
        public IActionResult GetLongUrl(string shortUrl)
        {
            var longUrl = _linkShortenerService.GetLongUrl(shortUrl);

            if (longUrl == null)
                return NotFound("URL não encontrada.");

            return Redirect(longUrl);
        }
    }
}
