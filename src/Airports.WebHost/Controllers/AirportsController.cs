using System.Collections.Generic;
using System.Threading.Tasks;
using Airports.WebHost.Domain;
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
        private readonly IAirports _airports;

        public AirportsController(IAirports airports)
        {
            _airports = airports;
        }

        [HttpGet("{code}")]
        public Task<Airport> GetAsync(string code) => _airports.ByCodeAsync(code);
    }
}