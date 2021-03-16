using Microsoft.AspNetCore.Mvc;


namespace spritely.Controllers
{
    [ApiController]
    [Route("")]
    public class ShortenController : ControllerBase
    {
        public ShortenController()
        {
           // _logger = logger;
        }

        [HttpGet("{shortUrl}")]
        public RedirectResult Get(string shortUrl)
        {
            var redirect = new RedirectResult($"https://www.google.com?search={shortUrl}");

            return redirect;
        }

        [HttpPost]
        public string Post()
        {
            return "test";
        }
    }
}
