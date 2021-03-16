using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spritely.Repositories;
using spritely.Services;

namespace spritely.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly UrlStore _store;
        private readonly RandomKeyGenerator _randomKeyGenerator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, RedisService redisService, RandomKeyGenerator random)
        {
            _logger = logger;
            _store = new UrlStore(redisService);
            _randomKeyGenerator = random;
        }

        [HttpGet]
        public string Get()
        {
            return _randomKeyGenerator.getRandomString(6) + _store.getValue("test");
        }
    }
}
