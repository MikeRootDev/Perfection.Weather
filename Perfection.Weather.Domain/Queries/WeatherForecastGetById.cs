using MediatR;
using Perfection.Weather.Domain.Models.V0;

namespace Perfection.Weather.Domain.Queries
{
    public record WeatherForecastGetById(Guid id) : IRequest<WeatherForecast>
    {
        public Guid Id { get; set; }
    }
}
