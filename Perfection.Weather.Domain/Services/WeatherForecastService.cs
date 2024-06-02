using Microsoft.Extensions.Logging;
using Perfection.Weather.Domain.Interfaces;

namespace Perfection.Weather.Domain.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<IWeatherForecastService> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }
    }
}
