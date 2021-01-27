using System.Threading.Tasks;
using Airports.WebHost.Domain.Airports;
using Airports.WebHost.Domain.Airports.Dtos;
using Airports.WebHost.Domain.Infrastructure;
using Airports.WebHost.Domain.Models;
using Airports.WebHost.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airports.WebHost.Controllers
{
    [ApiController]
    [Route("api/airports")]
    [AllowAnonymous]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airports;

        public AirportsController(IAirportService airports)
        {
            _airports = airports;
        }

        [HttpGet("{code}")]
        public Task<Airport> GetAsync(string code) => _airports.ByCodeAsync(code);

        [HttpPost("difference")]
        public Task<DifferenceResponse> DifferenceAsync([FromBody] DifferenceBetweenAirportsRequest request)
            => _airports.DifferenceAsync(request);
    }
}