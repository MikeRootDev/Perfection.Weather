using MediatR;
using Perfection.Weather.Domain.Models.V0;

namespace Perfection.Weather.Domain.Queries
{
    public class WeatherForecastGetAll: IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
