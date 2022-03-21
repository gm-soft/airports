using System;
using System.Threading.Tasks;
using Airports.WebHost.Domain.Airports;
using Airports.WebHost.Domain.Airports.Dtos;
using Airports.WebHost.Domain.Infrastructure;
using Airports.WebHost.Domain.Models;
using Airports.WebHost.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

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
        public Task<Airport> GetAsync(string code)
        {
            if(code == null)
            {
                Log.Information("Code is not correct of empty. Cannot find an airport with a code of {Code}", code);                
                return null; //Верно ли возвращать здесь Null?
            }

            Log.Information("Get an airport with a code of {Code}", code);
            return _airports.ByCodeAsync(code);
        }            

        [HttpPost("difference")]
        public Task<DifferenceResponse> DifferenceAsync([FromBody] DifferenceBetweenAirportsRequest request)
        {
            if(request == null)
            {
                Log.Information($"Request is empty. Cannot conduct a method {nameof(DifferenceAsync)}");
                return null; //Тот же вопрос о Null
            }

            Log.Information("Request sent is correct. Sending difference beetween {FirstLocation} and {SecondLocation}", 
                request.First, request.Second);
            return _airports.DifferenceAsync(request);            
        }
    }
}