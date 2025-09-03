using Microsoft.AspNetCore.Mvc;

namespace DotNetPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Services.IWeatherForecastService _service;

        public WeatherForecastController(Services.IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Services.WeatherForecast> Get()
        {
            return _service.GetForecast();
        }
    }
}
