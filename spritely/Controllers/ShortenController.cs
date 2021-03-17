using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using spritely.Repositories;
using spritely.Services;
using System;

namespace spritely.Controllers
{
    [ApiController]
    [Route("")]
    public class ShortenController : ControllerBase
    {
        private readonly UrlStore _urlStore;
        private readonly RandomKeyGenerator _random;
        private readonly string _homeUrl;
        private readonly int _shortUrlLength;

        public ShortenController(RedisService redisService, RandomKeyGenerator random, IConfiguration config)
        {
            // TODO: implement logger
            _urlStore = new UrlStore(redisService);
            _random = random;
            _homeUrl = config.GetValue<string>("ui");
            _shortUrlLength = config.GetValue<int>("shortUrlLength");
        }

        [HttpGet("{shortUrl}")]
        public RedirectResult Get(string shortUrl)
        {
            try
            {
                var actualUrl = _urlStore.getValue(shortUrl);

                if (actualUrl != null)
                {
                    return new RedirectResult(new UriBuilder(actualUrl).Uri.AbsoluteUri);
                }
            }
            catch
            {
            }
            return new RedirectResult(_homeUrl);
        }

        [HttpGet("api/shorten")]
        public string GetShort([FromQuery(Name = "url")] string url)
        {
            var shortUrl = _random.getRandomString(_shortUrlLength);
            _urlStore.setValue(shortUrl, url);
            return $"{HttpContext.Request.Host}/{shortUrl}"; 
        }
    }
}
