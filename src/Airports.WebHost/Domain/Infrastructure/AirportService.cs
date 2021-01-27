using System;
using System.Threading.Tasks;
using Airports.WebHost.Controllers;
using Airports.WebHost.Domain.Models;
using Airports.WebHost.Domain.ValueObjects;

namespace Airports.WebHost.Domain.Infrastructure
{
    public class AirportService : IAirportService
    {
        private readonly IApi _api;

        public AirportService(IApi api)
        {
            _api = api;
        }

        public async Task<Airport> ByCodeAsync(string code)
        {
            code.ThrowIfNull(nameof(code));

            return (await _api.GetAsync<AirportResponse>($"airports/{code.ToUpper()}")).Airport();
        }

        public async Task<Difference> DifferenceAsync(DifferenceBetweenAirportsRequest request)
        {
            Airport first = await ByCodeAsync(request.First);
            Airport second = await ByCodeAsync(request.Second);

            return new Difference(first.Location, second.Location);
        }
    }
}