using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.API.Controllers;

public class TemperatureRequest
{
    public int Min {get; set;}
    public int Max {get; set;}
}

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecast;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecast = weatherForecastService;
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromQuery]int count, [FromBody]TemperatureRequest request)
    {
        if (count < 0 || request.Max < request.Min)
        {
            return BadRequest("Count has to be greater than 0, and max must to be greater than min value");
        }
        var result = _weatherForecast.Get(count, request.Min, request.Max);
        return Ok(result);
    }
    
}
