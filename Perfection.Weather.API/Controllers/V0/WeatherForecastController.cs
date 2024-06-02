using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Perfection.Weather.Domain.Interfaces;
using Perfection.Weather.Domain.Queries;

namespace Perfection.Weather.API.Controllers.V0
{
    [ApiVersion("0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IMapper _mapper;

        public WeatherForecastController(
            IWeatherForecastService weatherForecastService,
            ILogger<WeatherForecastController> logger,
            IMapper mapper,
            IMediator mediator)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new WeatherForecastGetAll();
                var response = await _mediator.Send(query, cancellationToken);
                var finishedResponse = _mapper.Map<WeatherForecastGetById>(response);
                return Ok(finishedResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on {method}: Exception {ex}", nameof(GetAll), ex);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new WeatherForecastGetById(id);
                var response = await _mediator.Send(query, cancellationToken);
                var finishedResponse = _mapper.Map<WeatherForecastGetById>(response);
                return Ok(finishedResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on {method}: Exception {ex}", nameof(Get), ex);
                throw;
            }
        }

        //[HttpPost]
        //public async Task<ActionResult> Post()
        //{

        //}

        //[HttpPut]
        //public async Task<ActionResult> Put()
        //{

        //}

        //[HttpDelete]
        //public async Task<ActionResult> Delete()
        //{

        //}
    }
}
